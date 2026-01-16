using Microsoft.AspNetCore.Mvc;

namespace CrossplatformProgramming.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }


}
