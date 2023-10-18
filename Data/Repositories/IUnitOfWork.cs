
using Common.Models;

namespace Data.Repositories;
public interface IUnitOfWork
{
    public IWordRepository WordRepository { get; }
    public Task<Result<None>> SaveChanges();
}