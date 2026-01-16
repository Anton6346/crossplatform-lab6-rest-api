using Microsoft.AspNetCore.Mvc;

namespace CrossplatformProgramming.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        
        public int TeacherId { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public Teacher? Teacher { get; set; }

        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}