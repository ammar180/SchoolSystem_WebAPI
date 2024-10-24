using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SchoolSystem.Models.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [DisplayName("Subject Name")]
        public string Name { get; set; }
        public List<Student>? Students { get; set; }
    }
}
