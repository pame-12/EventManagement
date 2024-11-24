using EventManagement.Api.Interfaces;
using EventManagement.Api.Models;

namespace EventManagement.Api.Services
{
    public class EventService : IEventService
    {
        private readonly List<Event> _events = new();

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await Task.FromResult(_events);
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(ev);
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            newEvent.Id = _events.Count + 1;
            _events.Add(newEvent);
            return await Task.FromResult(newEvent);
        }

        public async Task<Event> UpdateEventAsync(int id, Event updatedEvent)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                ev.Name = updatedEvent.Name;
                ev.Description = updatedEvent.Description;
                ev.StartDate = updatedEvent.StartDate;
                ev.EndDate = updatedEvent.EndDate;
            }
            return await Task.FromResult(ev);
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                _events.Remove(ev);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
