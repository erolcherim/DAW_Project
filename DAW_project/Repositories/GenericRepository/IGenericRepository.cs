namespace DAW_Project.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        //Create
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        //Read
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        //Task<TEntity> GetByNameAsync(string name);

        //Update
        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);

        //Delete
        Task Delete(TEntity entity);
        Task DeleteRange(IEnumerable<TEntity> entities);

        //Save
        Task<bool> SaveAsync();
    }
}
