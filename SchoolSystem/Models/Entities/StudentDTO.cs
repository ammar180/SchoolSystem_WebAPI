namespace SchoolSystem.Models.Entities
{
    public class StudentDTO
    {
        public string UserName { get; set; }
        public string StudentFullName { get; set; }
        public string StudentEmail { get; set; }
        public string Password { get; set; }
        public int SubjectId { get; set; }
        public int InstractorId { get; set; }
    }
}
