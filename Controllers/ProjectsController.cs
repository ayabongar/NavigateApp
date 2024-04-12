using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NavigationApp.Models;

namespace NavigationApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        //data file
        private readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Data.json");

        public ProjectsController()
        {
            // Checking json if ti exists
            if (!System.IO.File.Exists(_jsonFilePath))
            {
                throw new FileNotFoundException($"JSON file not found at {_jsonFilePath}");
            }
        }

        [HttpGet("GetProjects")]
        public ActionResult<IEnumerable<Root>> GetProjects(string searchQuery = "")
        {
            try
            {
                // Read JSON data from the file
                string jsonData = System.IO.File.ReadAllText(_jsonFilePath);

                //Deserializing JSON data into a list of Root objects
                List<Root> projects = JsonSerializer.Deserialize<List<Root>>(jsonData);

                //IEnumerable<Root> projects = JsonSerializer.Deserialize<IEnumerable<Root>>(jsonData);

                //filtering based on search query
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    string lowerSearchQuery = searchQuery.ToLower();
                    projects = projects.Where(p => p.name.ToLower().Contains(lowerSearchQuery) ||
                                                    p.groups.Any(g => g.name.ToLower().Contains(lowerSearchQuery)))
                                       .ToList();
                }

                return Ok(projects);
            }
            catch (Exception ex)
            {
                // error logging
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
