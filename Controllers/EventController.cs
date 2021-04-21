using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Threading.Tasks;

namespace Event_Portal.Controllers
{

  [ApiController]
  [Route("/events")]



  public class EventController : ControllerBase
  {

    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "JVGSRZVMU5Iw6TtGygVyEPUf41Zk40viN3UxWR76",
      BasePath = "https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    IFirebaseClient client;



    private readonly IUserRepo userControllerRepository;
    public EventController(IUserRepo userControllerRepository)
    {

      this.userControllerRepository = userControllerRepository;

      client = new FireSharp.FirebaseClient(config);
    }




    // GET /events
    [HttpGet]
    public IEnumerable<Event> GetEvents()
    {
      FirebaseResponse res = client.Get(@"events");
      Dictionary<string, Event> data = JsonConvert.DeserializeObject<Dictionary<string, Event>>(res.Body.ToString());
      var list = data.Select(x => x.Value);

      return list;

    }

    // GET /events/{id}
    [HttpGet("{id}")]

    public async Task<Event> GetEvent(String id)
    {
      var response = await client.GetTaskAsync("events/" + id);

      if (client != null)
      {
        Console.WriteLine("Connection is established.");
      }

      Event result = response.ResultAs<Event>();

      return result;
    }

    // POST /events
    [HttpPost]
    public async Task<EventDto> CreateEvent(CreateEventDto eventDto)

    {
      Event myEvent = new()
      {
        Id = Guid.NewGuid(),
        HostId = eventDto.HostId,
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };


      FirebaseResponse res = client.Get(@"users/" + myEvent.HostId);
      User hostUser = JsonConvert.DeserializeObject<User>(res.Body.ToString());


      if(hostUser != null)
      {
        var response = await client.PushTaskAsync("events", myEvent);
        EventDto result = response.ResultAs<EventDto>();  

        Console.WriteLine("Added hostId");

        Console.WriteLine("Pushed new event");

        return result;


      } else {
        Console.WriteLine("Wrong hostID");
         return null;
      }

      


    }

    // PUT /events/{id}

    [HttpPut("{id}")]

    public async Task<UpdateEventDto> UpdateEvent(String id, UpdateEventDto eventDto)
    {

      UpdateEventDto updatedEvent = new UpdateEventDto
      {
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };

      var response = await client.UpdateTaskAsync("events/" + id, updatedEvent);
      Event result = response.ResultAs<Event>();

      Console.WriteLine("Event's information has been updated.");

      return updatedEvent;

    }

    // DELETE /events/{id}
    [HttpDelete("{id}")]
    public async Task<String> DeleteEvent(String id)
    {
      var response = await client.DeleteTaskAsync("events/" + id);


      return "This event has been removed.";
    }


    // POST User into Event

    [HttpPost("addEventToUser/{eventId}/{userId}")]

    public async Task<User> AddEventToUser(String eventId, String userId)
    {


      var existingUser = await client.GetTaskAsync("users/" + userId);
      var existingEvent = await client.GetTaskAsync("events/" + eventId);


      User user = existingUser.ResultAs<User>();
      Event myEvent = existingEvent.ResultAs<Event>();


      user.JoinedEvents.Add(myEvent);
      var rs = await client.SetTaskAsync("users/" + userId, user);


      return user;



    }

    // Create new Method here

    [HttpPost("addUserToEvent/{userId}/{eventId}")]
    public async Task<Event> AddUserToEvent(String userId, String eventId)
    {

      var existingUser = await client.GetTaskAsync("users/" + userId);
      var existingEvent = await client.GetTaskAsync("events/" + eventId);


      User user = existingUser.ResultAs<User>();
      Event myEvent = existingEvent.ResultAs<Event>();


      myEvent.JoinedUsers.Add(user);
      var rs = await client.SetTaskAsync("events/" + eventId, myEvent);



      return myEvent;



    }



  }






}