using SchoolSystem.Models.Entities;

namespace SchoolSystem.Models.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Student? ValidateUserNamePassword(string userName, string password);
    }
}
