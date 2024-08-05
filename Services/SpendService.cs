using BlazorAppSpendsRegister.Models;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorAppSpendsRegister.Services
{
    public class SpendService : ISpendService
    {
        private readonly ILocalStorageService _localStorageService;
        public SpendService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        private string spendsLocalStorageKey => "spendKey";

        public async Task<List<Spend>> GetSpends()
        {
            var spendsJson = await _localStorageService.GetItemAsync<string>(spendsLocalStorageKey);
            if (string.IsNullOrEmpty(spendsJson))
                return new();

            return JsonSerializer.Deserialize<List<Spend>>(spendsJson);

        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendsJson = JsonSerializer.Serialize(spends);

            await _localStorageService.SetItemAsync(spendsLocalStorageKey, spendsJson);
        }
    }
}