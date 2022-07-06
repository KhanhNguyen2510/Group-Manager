using AutoMapper;
using AutoMapper.QueryableExtensions;
using GM.Data.EFs;
using System.Linq.Expressions;

namespace GM.Data.Repositories;

public interface IDataRepository<TEntity> where TEntity : class
{
    public Task<List<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>>[] filters,
        string orderBy,
        string includeProperties,
        int skip,
        int limit);

    public Task<List<TEntity>> FindAsync(
       Expression<Func<TEntity, bool>>[] filters, string orderBy,
       string includeProperties);

    public Task<List<TDto>> FindAsync<TDto>(
        Expression<Func<TEntity, bool>>[] filters,
        string orderBy,
        string includeProperties,
        int skip,
        int limit);

    public Task<FindResult<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>>[] filters,
        string orderBy,
        int skip,
        int limit);
    public Task<FindResult<TEntity>> FindIncludeAsync(
       Expression<Func<TEntity, bool>>[] filters,
       string orderBy,
       string includeProperties,
       int skip,
       int limit);

    public Task<FindResult<TDto>> FindAsync<TDto>(
        Expression<Func<TEntity, bool>>[] filters,
        string orderBy,
        int skip,
        int limit);

    public Task<TEntity> FindOneAsync(object id);
    public Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] filters, string includeProperties = null);
    public Task<TDto> FindOneAsync<TDto>(Expression<Func<TEntity, bool>>[] filters, string includeProperties = null);
    public Task InsertAsync(TEntity entity);
    public Task InsertAsync(IEnumerable<TEntity> entities);
    public void Update(TEntity entityUpdate);
    public void Update(IEnumerable<TEntity> entityUpdates);
    public Task SaveChangeAsync();
}

public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly GMDbContext _context;


    protected DataRepository(GMDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>>[] filters,
        string orderBy,
        string includeProperties,
        int skip,
        int limit)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }

        if (skip > 0)
            query = query.Skip(skip);

        if (limit > 0)
            query = query.Take(limit);

        return await query.ToListAsync();
    }


    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>>[] filters, string orderBy, string includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }


        return await query.ToListAsync();
    }

    public async Task<List<TDto>> FindAsync<TDto>(Expression<Func<TEntity, bool>>[] filters, string orderBy,
        string includeProperties, int skip, int limit)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }

        if (skip > 0)
            query = query.Skip(skip);

        if (limit > 0)
            query = query.Take(limit);


        return await query.ProjectTo<TDto>(GetMapperConfiguration<TDto>()).ToListAsync();
    }

    public async Task<FindResult<TEntity>> FindAsync(Expression<Func<TEntity, bool>>[] filters, string orderBy,
        int skip, int limit)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }

        if (skip > 0)
            query = query.Skip(skip);

        if (limit > 0)
            query = query.Take(limit);

        var items = await query.ToListAsync();
        long totalCount = await _dbSet.CountAsync();
        return FindResult<TEntity>.Success(items, totalCount);
    }

    public async Task<FindResult<TDto>> FindAsync<TDto>(Expression<Func<TEntity, bool>>[] filters, string orderBy,
        int skip,
        int limit)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }

        if (skip > 0)
            query = query.Skip(skip);

        if (limit > 0)
            query = query.Take(limit);

        var items = await query.ProjectTo<TDto>(GetMapperConfiguration<TDto>()).ToListAsync();
        long totalCount = await _dbSet.CountAsync();
        return FindResult<TDto>.Success(items, totalCount);
    }

    public async Task<FindResult<TEntity>> FindIncludeAsync(Expression<Func<TEntity, bool>>[] filters, string orderBy, string includeProperties, int skip, int limit)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var propertyName = orderBy.Split(',')[0];
            var propertyInfo = typeof(TEntity).GetProperty("");
            if (!string.IsNullOrEmpty(propertyName) && propertyInfo != null)
                query = query.OrderBy(x => propertyInfo.GetType().GetProperty(propertyName).GetValue(propertyInfo));
        }

        if (skip > 0)
            query = query.Skip(skip);

        if (limit > 0)
            query = query.Take(limit);

        var items = await query.ToListAsync();
        long totalCount = await _dbSet.CountAsync();
        return FindResult<TEntity>.Success(items, totalCount);
    }

    public async Task<TEntity> FindOneAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] filters, string includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TDto> FindOneAsync<TDto>(Expression<Func<TEntity, bool>>[] filters,
        string includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (filters != null && filters.Any())
        {
            query = filters.Aggregate(query, (current, filter) => current.Where(filter));
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.ProjectTo<TDto>(GetMapperConfiguration<TDto>()).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task InsertAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entityUpdate)
    {
        _dbSet.Update(entityUpdate);
    }

    public void Update(IEnumerable<TEntity> entityUpdates)
    {
        _dbSet.UpdateRange(entityUpdates);
    }

    public async Task SaveChangeAsync()
    {   
         await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();
        return;
    }


    private static MapperConfiguration GetMapperConfiguration<TDto>()
    {
        var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TDto>());
        return configuration;
    }

   
}