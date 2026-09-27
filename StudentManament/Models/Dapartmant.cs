
using System.ComponentModel.DataAnnotations;

namespace Student_Managmet.Models
{
    public class Departmant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department Name")]
     
        public string Name { get; set; }
        
        public ICollection<Student>? Students { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Instructor>? Instructors { get; set; } 
    }
}