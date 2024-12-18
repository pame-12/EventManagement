﻿using EventManagement.Api.Models;

namespace EventManagement.Api.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<Event> CreateEventAsync(Event newEvent);
        Task<Event> UpdateEventAsync(int id, Event updatedEvent);
        Task<bool> DeleteEventAsync(int id);
    }
}
