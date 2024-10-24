using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        [MaxLength(20, ErrorMessage = "username Max Length is 20 char")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Student Name is Required")]
        public string StudentFullName { get; set; }
        public string StudentEmail { get; set; }
        public string Password { get; set; }
        [ForeignKey("SubjectId")]
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
