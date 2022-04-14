using Blogs.Repositories;

namespace Blogs.Service.Implements;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
{
    private IGenericRepository<TEntity> _genericRepository;

    public GenericService(IGenericRepository<TEntity> genericRepository)
    {
        this._genericRepository = genericRepository;
    }

    public async Task Delete(int id)
    {
        await _genericRepository.Delete(id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _genericRepository.GetAll(); 
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _genericRepository.GetById(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        return await _genericRepository.Insert(entity);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        return await _genericRepository.Update(entity);
    }
}