namespace DAW_Project.Services
{
    public interface ISaleService
    {
        Task<int?> CalculateSaleValue(int id);
    }
}