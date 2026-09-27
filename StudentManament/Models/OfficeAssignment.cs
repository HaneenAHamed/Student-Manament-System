using System.ComponentModel.DataAnnotations;

namespace Student_Managmet.Models
{
    public class OfficeAssignment
    {


        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; } = string.Empty;
        public Instructor? Instructor { get; set; }
      



    }
}
