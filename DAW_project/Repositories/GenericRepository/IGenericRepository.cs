namespace DAW_Project.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        //Create
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        //Read
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        //Task<TEntity> GetByNameAsync(string name);

        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //Save
        Task<bool> SaveAsync();
    }
}
