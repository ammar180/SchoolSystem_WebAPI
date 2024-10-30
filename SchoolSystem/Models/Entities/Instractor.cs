using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models.Entities
{
    public class Instractor
    {
        public int InstractorId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public List<Student>? Students { get; set; }
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
