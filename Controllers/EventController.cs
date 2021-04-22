using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
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




    public EventController()
    {


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
    public async Task<Event> CreateEvent(CreateEventDto eventDto)

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


      Console.WriteLine(hostUser);

      if(hostUser != null)
      {
        var response = await client.PushTaskAsync("events", myEvent);
        
        var eventsList = GetEvents();
        var lastPushedEvent = eventsList.ElementAt(eventsList.Count() - 1);
        hostUser.CreatedEvents.Add(lastPushedEvent);

        var rs = await client.SetTaskAsync("users/" + myEvent.HostId, hostUser);



          // Push the last created event to CreatedEvents 

        FirebaseResponse resEvent = client.Get(@"events");
        User createdEvent = JsonConvert.DeserializeObject<User>(res.Body.ToString());

        Event result = response.ResultAs<Event>();  


        Console.WriteLine("Added hostId");

        Console.WriteLine("Pushed new event");


       // hostUser.CreatedEvents.Add(result);

        return lastPushedEvent;

      } 
      
      else {
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