namespace Computer_club.Domain.Services.ClubServices.HistoryEquipmentService;

public interface IHistoryEquipService<T>
{
    Task<List<T>?> GetAllForThePeriodAsync(int pageNumber, int pageSize, DateTime start, DateTime end);
    Task<int?> GetSumExpensesAsync(DateTime start, DateTime end);
}