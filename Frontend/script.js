document.addEventListener("DOMContentLoaded", function() {
    const projectsDropdown = document.getElementById("projectsDropdown");
    const searchBar = document.getElementById("searchBar");
    const systemsList = document.getElementById("systemsList");
    const userAgentsList = document.getElementById("userAgentsList");
    const goToProjectsButton = document.getElementById("goToProjectsButton");

    goToProjectsButton.addEventListener("click", function() {
        projectsDropdown.classList.toggle("active");
    });

    searchBar.addEventListener("input", function() {
        const query = searchBar.value.trim().toLowerCase(); // Trim whitespace and convert to lowercase
        filterList(systemsList, query);
        filterList(userAgentsList, query);
    });

    // Fetch data from the backend API
    async function fetchData(url) {
        try {
            const response = await fetch(url);
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            const data = await response.json();
            return data;
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    }

    // Populate Systems and User Agents lists with fetched data
    async function populateLists() {
        const data = await fetchData("/api/projects/GetProjects");
        if (data) {
            populateList(systemsList, data[0].groups);
            populateList(userAgentsList, data[1].groups);
        }
    }

    // Function to populate a list with items
    function populateList(listElement, items) {
        listElement.innerHTML = "";
        items.forEach(item => {
            const li = document.createElement("li");
            li.textContent = item.name; // Assuming 'name' is the property containing the item's name
            listElement.appendChild(li);
        });
    }

    // Function to filter and display search results
    function filterList(list, query) {
        const items = list.querySelectorAll("li");
        items.forEach(item => {
            const itemName = item.textContent.toLowerCase();
            if (itemName.includes(query)) {
                item.style.display = "block";
            } else {
                item.style.display = "none";
            }
        });
    }

    // Call the function to populate lists on page load
    populateLists();

    // Close the dropdown when clicking outside of it
    document.addEventListener("click", function(event) {
        if (!event.target.closest("#projectsDropdown")) {
            projectsDropdown.classList.remove("active");
        }
    });
});
