using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateWebApp.Services
{
    public class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreService()
        {
            _connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"), "NHibernateWebApp");
            _connection.ConnectAsync().Wait();
        }

        public async Task SendEventAsync<T>(T eventData)
        {
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventData));
            var myEvent = new EventData(Guid.NewGuid(), "testEvent", true, data, null);
            await _connection.AppendToStreamAsync("test-stream", ExpectedVersion.Any, myEvent);
        }

        public async Task<IEnumerable<T>> ReadEventsAsync<T>(int pageSize = 10, long pageNumber = 1)
        {
            var streamEvents = await _connection.ReadStreamEventsForwardAsync("test-stream", (pageNumber - 1) * pageSize, pageSize, false);

            var events = streamEvents.Events.Select(e => Encoding.UTF8.GetString(e.Event.Data));
            return events.Select(JsonConvert.DeserializeObject<T>);
        }
    }
}
