using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models.Entities
{
    public class InstractorDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string SubjectName { get; set; }
    }
}
