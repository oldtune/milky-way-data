using Common.Models;
using Data.Entities;

namespace Data.Repositories;
public interface IWordRepository : IBaseRepository<WordRecord>
{
    public Task<Result<WordRecord>> FindFullDefinition(string word);
}