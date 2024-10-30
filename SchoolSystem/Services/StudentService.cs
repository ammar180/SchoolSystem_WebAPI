using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepo;
        private ISubjectRepository subjectRepo;
        private IJwtTokenService _jwtTokenService;
        private Validation validation = new Validation();


        public StudentService(
            IStudentRepository _studentRepo,
            ISubjectRepository _subjectRepo,
            IJwtTokenService jwtTokenService
            )
        {
            studentRepo = _studentRepo;
            subjectRepo = _subjectRepo;
            _jwtTokenService = jwtTokenService;
        }

        public object GetAllStudentsAndSubjects()
        {
            var students = studentRepo.GetAll();
            var subjects = subjectRepo.GetAll();

            var result = students.Join(subjects,
                student => student.SubjectId, subject => subject.SubjectId,
                (student, subject) => new 
                {
                    Username = student.UserName,
                    StudentName = student.StudentFullName,
                    Email = student.StudentEmail,
                    SubjectName = subject.Name 
                });
            return result;
        }

        public string RemoveStudent(int id)
        {
            var student = studentRepo.GetById(id);
            if(student != null)
            {
                studentRepo.Delete(student);
                return "Student deleted Successfully";
            }
            return "Not Found!";
        }

        public object StudentLogin(string userName, string password)
        {
            var result = studentRepo.ValidateUserNamePassword(userName, password);
            if (result == null)
                throw new InvalidOperationException($"No Student found with User Name: {userName} and Password: {password}");
            else
            {
                var token = _jwtTokenService.GenerateToken(userName, result.StudentEmail);
                return new { result, token};
            }
        }

        public string StudentRegestration(StudentDTO dto)
        {
            try
            {
                Student stud = new Student()
                {
                    UserName = dto.UserName,
                    StudentFullName = dto.StudentFullName,
                    StudentEmail = dto.StudentEmail,
                    Password = dto.Password,
                    InstractorId = dto.InstractorId,
                };

                var problems = validation.GetValidationResult(stud);
                if (problems.Length != 0)
                    throw new InvalidDataException(problems);

                Subject? subject = subjectRepo.GetById(dto.SubjectId);

                if(subject != null)
                    stud.SubjectId = dto.SubjectId;

                studentRepo.Add(stud);
                return $"Student Regester Successfully with, {subject?.Name ?? "No Subject"}";
            }
            catch (InvalidDataException probs)
            {
                return $"There are some Problems:\n{probs.Message}";
            }
        }

        public string UpdateSudentName(int id, string newName)
        {
            try
            {
                var std = studentRepo.GetById(id);
                if (std == null)
                    return "Student Not Found";

                std.StudentFullName = newName;
                var problems = validation.GetValidationResult(std);
                
                if (problems.Length != 0)
                    throw new InvalidDataException(problems);

                studentRepo.Update(std);

                return $"Student Name Updated Successfully";

            }
            catch (InvalidDataException probs)
            {
                return probs.Message;
            }
        }
    }
}
