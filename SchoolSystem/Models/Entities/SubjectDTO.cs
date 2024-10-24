namespace SchoolSystem.Models.Entities
{
    public class SubjectDTO
    {
        public string SubjectName { get; set; }
        public List<StudentDTO> Students { get; set; }
    }
}
