using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.Services
{
    public interface IStudentService
    {
        object GetAllStudentsAndSubjects();
        string RemoveStudent(int id);
        object StudentLogin(string userName, string password);
        public string StudentRegestration(StudentDTO dto);
        string UpdateSudentName(int id, string newName);
    }
}
