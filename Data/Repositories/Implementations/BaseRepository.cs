using System.Linq.Expressions;
using Common.Models;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;
public class BaseRepository<T> : IBaseRepository<T> where T : class, IDatabaseObject
{
    protected readonly DictionaryDbContext _db;
    protected readonly DbSet<T> _set;
    public BaseRepository(DictionaryDbContext db)
    {
        _db = db;
        _set = db.Set<T>();
    }

    public async Task<Result<None>> Add(T obj)
    {
        return await Result.FromValueTaskNone(() => _set.AddAsync(obj));
    }

    public async Task<Result<None>> AddRange(IEnumerable<T> collection)
    {
        return await Result.FromTask(() => _set.AddRangeAsync(collection));
    }

    public void Delete(T obj)
    {
        _set.Remove(obj);
    }

    public void DeleteRange(IEnumerable<T> collection)
    {
        _set.RemoveRange(collection);
    }

    public async Task<Result<T>> FindAsync(object primaryKey)
    {
        return await Result.FromValueTask(() => _set.FindAsync(primaryKey));
    }

    public async Task<Result<T>> FindAsync(params object[] primaryKeys)
    {
        return await Result.FromValueTask(() => _set.FindAsync(primaryKeys));
    }

    public async Task<Result<T>> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return await Result.FromTask(() => _set.FirstOrDefaultAsync());
        }

        return await Result.FromTask(() => _set.FirstOrDefaultAsync(predicate));
    }

    public async Task<Result<List<TResult>>> QueryAsync<TResult>(Expression<Func<T, TResult>> selector,
     Expression<Func<T, bool>> filter = null)
    {
        var refinedFilter = filter ?? ((T x) => true);
        return await Result.FromTask(() => _set.Where(refinedFilter).Select(selector).ToListAsync());
    }

    public async Task<Result<List<TResult>>> QueryAsync<TResult, TSort>(Expression<Func<T, TResult>> selector,
    Expression<Func<T, TSort>> sort,
    Expression<Func<T, bool>> filter = null,
    int skip = 0,
    int take = 0)
    {
        var refinedFilter = filter ?? ((T x) => true);
        return await Result.FromTask(() => _set.Where(refinedFilter)
        .OrderBy(sort)
        .Skip(skip)
        .Take(take)
        .Select(selector)
        .ToListAsync());
    }

    public void Update(T obj)
    {
        _set.Attach(obj);
        _set.Entry(obj).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T> collection)
    {
        _set.AttachRange(collection);

        foreach (var entity in collection)
        {
            _set.Entry(entity).State = EntityState.Modified;
        }
    }
}