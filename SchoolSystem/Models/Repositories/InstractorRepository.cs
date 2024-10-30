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
                .Include(i => i.Students)
                .Include(i => i.Subject)
                .Select(i => new Instractor()
                {
                    InstractorId = i.InstractorId,
                    Salary  = i.Salary,
                    Subject = i.Subject,
                    Students = i.Students
                    .Select( s => new Student 
                    { 
                        StudentFullName = s.StudentFullName,
                        StudentEmail = s.StudentEmail,
                        StudentId = s.StudentId,
                    }).ToList()
                })
                .ToList();
        }

        public Instractor? GetById(int Id)
        {
            return context.Instractors.SingleOrDefault(s => s.InstractorId == Id);
        }

        public void Update(Instractor Instractor)
        {
            //context.Instractors.Update(Instractor);
            context.SaveChanges();
        }

    }
}
