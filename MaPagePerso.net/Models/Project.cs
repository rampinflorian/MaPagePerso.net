using System;

namespace MaPagePerso.net.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
    }
}