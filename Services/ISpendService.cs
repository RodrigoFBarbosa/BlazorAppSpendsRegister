using BlazorAppSpendsRegister.Models;

namespace BlazorAppSpendsRegister.Services;

public interface ISpendService
{
    Task<List<Spend>> GetSpends();
    Task SaveSpends(List<Spend> spends);
}
