using InventoryHub.Shared;
using System.Net.Http.Json;

namespace InventoryHub.Client.Services;

public class InventoryService
{
    private readonly HttpClient _http;

    public InventoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<InventoryItemDto>> GetItemsAsync()
    {
        var items = await _http.GetFromJsonAsync<List<InventoryItemDto>>("http://localhost:5260/api/inventory");
        return items ?? new List<InventoryItemDto>();
    }

    public async Task AddItemAsync(InventoryItemDto item)
    {
        await _http.PostAsJsonAsync("http://localhost:5260/api/inventory", item);
    }
}