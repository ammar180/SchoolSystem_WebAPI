using SchoolSystem.Models.Entities;

namespace SchoolSystem.Services
{
    public interface ISubjectService
    {
        string Enrollment(int studentId, int subjectId);
        List<Subject>? GetEnrolledStudents();
        string NewSubject(SubjectDTO subjDto);
    }
}
