using System.Linq.Expressions;
using Common.Models;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;
public class UnitOfWork : IUnitOfWork
{
    readonly DictionaryDbContext _db;
    readonly IWordRepository _wordRepository;
    public UnitOfWork(DictionaryDbContext db,
    IWordRepository wordRepository)
    {
        _db = db;
        _wordRepository = wordRepository;
    }

    public IWordRepository WordRepository => _wordRepository;

    public async Task<Result<None>> SaveChanges()
    {
        return await Result.FromTaskNone(() => _db.SaveChangesAsync());
    }
}