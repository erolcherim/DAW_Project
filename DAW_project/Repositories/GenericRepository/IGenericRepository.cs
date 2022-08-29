namespace DAW_Project.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        //Create
        Task Create(TEntity entity);

        //Read
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        //Task<TEntity> GetByNameAsync(string name);

        //Update
        Task Update(TEntity entity);

        //Delete
        Task Delete(TEntity entity);

        //Save
        Task<bool> SaveAsync();
    }
}
