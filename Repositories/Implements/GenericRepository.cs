using Blogs.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Repositories.Implements;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly BlogContext _blogContext;

    public GenericRepository(BlogContext blogContext)
    {
        this._blogContext = blogContext;
    }

	// DELETE
    public async Task Delete(int id)
    {
		try
		{			
			var entity = await GetById(id);

			if(entity == null)
			{
				throw new Exception("The entity is null");
			}
			else
			{
				_blogContext.Set<TEntity>().Remove(entity);
				await _blogContext.SaveChangesAsync();
			}
		}
		catch (System.Exception ex)
		{
			throw new Exception(ex.Message);
		}		
    }

	// GET ALL 
    public async Task<List<TEntity>> GetAll()
    {
		try
		{
        	return await _blogContext.Set<TEntity>().ToListAsync();			
		}
		catch (System.Exception ex)
		{
			throw new Exception(ex.Message);
		}
    }

	// GET BY ID 
    public async Task<TEntity> GetById(int id)
    {
		try
		{
        	return await _blogContext.Set<TEntity>().FindAsync(id);	
		}
		catch (System.Exception ex)
		{			
			throw new Exception(ex.Message);
		}
    }

	// INSERT
    public async Task<TEntity> Insert(TEntity entity)
    {
		if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

		try
		{
			await _blogContext.Set<TEntity>().AddAsync(entity);
			await _blogContext.SaveChangesAsync();
			return entity;
		}
		catch (System.Exception ex)
		{			
			throw new Exception(ex.Message);
		}
    }

	// UPDATE
    public async Task<TEntity> Update(TEntity entity)
    {
		if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

		try
		{
			_blogContext.Set<TEntity>().Update(entity);
			await _blogContext.SaveChangesAsync();
			return entity;
		}
		catch (System.Exception ex)
		{			
			throw new Exception(ex.Message);
		}
    }
}