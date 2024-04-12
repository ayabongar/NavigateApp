namespace NavigationApp.Models
{
        public class Root
    {
        public int id { get; set; }
        public string? name { get; set; }
        public Image? image { get; set; }
        public List<Group>? groups { get; set; }
        public string? url { get; set; }
    }
}