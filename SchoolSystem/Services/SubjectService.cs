using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories;

namespace SchoolSystem.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        private readonly IStudentRepository _studentRepo;
        public SubjectService(ISubjectRepository subjectRepo, IStudentRepository studentRepo)
        {
            _subjectRepo = subjectRepo;
            _studentRepo = studentRepo;
        }

        public string Enrollment(int studentId, int subjectId)
        {
            var std = _studentRepo.GetById(studentId);
            if (std == null)
                throw new InvalidOperationException("Student Not Found");

            var subj = _subjectRepo.GetById(subjectId);
            if (subj == null)
                throw new InvalidOperationException("Subject Not Found");

            std.SubjectId = subjectId;
            std.Subject = subj;

            _subjectRepo.Update(subj);
            return $"Student '{std.UserName}' Subject Updated Successfully to '{subj.Name}'";
        }

        public List<Subject>? GetEnrolledStudents()
        {
            return _subjectRepo.GetSubjectsStudents();
        }

        public string NewSubject(SubjectDTO subjDto)
        {
            var subj = new Subject()
            {
                Name = subjDto.SubjectName,
            };
            if (subj.Name.Length < 3)
                throw new Exception("Invalid Subject Name");
            _subjectRepo.Add(subj);
            return "Subject Added Successfully!";
        }

    }
}
