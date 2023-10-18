using Common.Models;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;
public class WordRepository : BaseRepository<WordRecord>, IWordRepository
{
    public WordRepository(DictionaryDbContext context) : base(context)
    {
    }

    public async Task<Result<WordRecord>> FindFullDefinition(string word)
    {
        return await Result.FromTask(() =>
        _db.Words.Include(x => x.WordTypeLinks)
        .ThenInclude(x => x.WordMeanings)
        .ThenInclude(x => x.Examples)
        .Include(x => x.WordTypeLinks)
        .ThenInclude(x => x.WordType)
        .FirstOrDefaultAsync(x => x.Word == word));
    }
}