using SchoolSystem.Models.Repositories.RepositoriesHelpers;

namespace SchoolSystem.Models.Repositories
{
    public interface IRepositoryBase<T> : IEntityReader<T>, IEntityWriter<T>, IEntityRemover<T>
    {
    }
}
