using System.Net.Http.Json;
using EventManagement.Client.Models;

namespace EventManagement.Client.Services;

public class EventService
{
    private readonly HttpClient _httpClient;

    public EventService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Event>>("api/events");
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Event>($"api/events/{id}");
    }

    public async Task AddEventAsync(Event newEvent)
    {
        await _httpClient.PostAsJsonAsync("api/events", newEvent);
    }

    public async Task UpdateEventAsync(Event updatedEvent)
    {
        await _httpClient.PutAsJsonAsync($"api/events/{updatedEvent.Id}", updatedEvent);
    }

    public async Task DeleteEventAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/events/{id}");
    }

    public async Task CreateEventAsync(Event newEvent)
    {
        var response = await _httpClient.PostAsJsonAsync("api/events", newEvent);
        response.EnsureSuccessStatusCode();
    }

}

