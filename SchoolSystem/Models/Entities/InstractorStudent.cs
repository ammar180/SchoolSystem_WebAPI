using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models.Entities
{
    public class InstractorStudent
    {
        [ForeignKey("InstracotrId")]
        public int InstractorId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public Instractor Instractor { get; set; }
        public Student Student { get; set; }
    }
}
