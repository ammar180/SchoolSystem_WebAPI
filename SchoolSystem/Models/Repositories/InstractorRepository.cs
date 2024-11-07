using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models.Entities;

namespace SchoolSystem.Models.Repositories
{
    public class InstractorRepository : IInstractorRepository
    {
        private readonly ApplicationDbContext context;
        public InstractorRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void Add(Instractor Instractor)
        {
            context.Instractors.Add(Instractor);
            context.SaveChanges();
        }

        public void Delete(Instractor Instractor)
        {
            context.Instractors.Remove(Instractor);
            context.SaveChanges();
        }

        public List<Instractor> GetAll()
        {
            return context.Instractors
                .Include(i => i.Subject)
                .Include(i => i.Students)
                .ThenInclude(i => i.Student)
                .Select(i => new Instractor()
                {
                    InstractorId = i.InstractorId,
                    Name = i.Name,
                    Salary  = i.Salary,
                    Subject = i.Subject,
                    Students = i.Students.Select(s => new InstractorStudent { Student = new Student { StudentFullName = s.Student.StudentFullName} }).ToList(),
                })
                .ToList();
        }

        public Instractor? GetById(int Id)
        {
            return context.Instractors.Include(i => i.Students).SingleOrDefault(s => s.InstractorId == Id);
        }

        public void Update(Instractor Instractor)
        {
            //context.Instractors.Update(Instractor);
            context.SaveChanges();
        }

    }
}
