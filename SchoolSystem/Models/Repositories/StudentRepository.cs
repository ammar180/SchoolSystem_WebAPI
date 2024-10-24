using SchoolSystem.Models.Entities;
using SchoolSystem.Models.Repositories.RepositoriesHelpers;
using System.Linq;

namespace SchoolSystem.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Delete(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student? GetById(int Id)
        {
            return context.Students.SingleOrDefault(s => s.StudentId == Id);
        }

        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }

        public Student? ValidateUserNamePassword(string userName, string password)
        {
            return context.Students.FirstOrDefault(s => s.UserName == userName && s.Password == password);
        }
    }
}
