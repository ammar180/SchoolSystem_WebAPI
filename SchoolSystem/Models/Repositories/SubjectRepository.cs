using SchoolSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Models.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext context;
        public SubjectRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Subject Entity)
        {
            context.Subjects.Add(Entity);
            context.SaveChanges();
        }

        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }

        public Subject? GetById(int Id)
        {
            return context.Subjects.FirstOrDefault(i => i.SubjectId == Id);
        }

        public List<Subject>? GetSubjectsStudents()
        {
            return context.Subjects
                .Include(s => s.Students)
                .Select(sub => new Subject
                {
                    SubjectId = sub.SubjectId,
                    Name = sub.Name,
                    Students = sub.Students.Select(x => new Student
                    {
                        StudentId = x.StudentId,
                        UserName = x.UserName,
                        StudentFullName = x.StudentFullName,
                        StudentEmail = x.StudentEmail,

                    }).ToList()
                })
                .ToList();
        }

        public bool IsExist(int id)
        {
            return context.Subjects.Any(i => i.SubjectId == id);
        }

        public void Update(Subject Entity)
        {
            context.SaveChanges();
        }
    }
}
