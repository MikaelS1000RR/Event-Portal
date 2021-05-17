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
using Microsoft.AspNetCore.Authorization;

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

   /*   DateTimeOffset currentTime = DateTimeOffset.Now;
      Console.WriteLine(currentTime);

      foreach (var i in list)
      {
        if(currentTime >= i.EndDateTime) 
        {
          Console.WriteLine("Delete " + i.EndDateTime);
        } 
        else 
        {
          Console.WriteLine("Too early " + i.EndDateTime);
        }
      } */

      return list;

    }


    [HttpPost]
    [Route("/filter-events")]

    public IEnumerable<Event> GetFilteredEvents([FromBody] string[] accessTypes)
    {
      FirebaseResponse res = client.Get(@"events");
      Dictionary<string, Event> data = JsonConvert.DeserializeObject<Dictionary<string, Event>>(res.Body.ToString());
      var emptyList = new List<Event>();


      if (accessTypes.Contains("public") && accessTypes.Contains("private"))
      {
        var publicEvents = data.Select(x => x.Value).Where(x => x.Access == "private" || x.Access == "public");
        return publicEvents;
      }
      else if (accessTypes.Contains("private"))
      {

        var privateEvents = data.Select(x => x.Value).Where(x => x.Access == "private");
        return privateEvents;
      }
      else if (accessTypes.Contains("public"))
      {
        var publicEvents = data.Select(x => x.Value).Where(x => x.Access == "public");
        return publicEvents;
      }
      return emptyList;

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
    [Authorize]
    [HttpPost]
    public async Task<Event> CreateEvent(CreateEventDto eventDto)

    {

      string[] pictures ={"https://images.pexels.com/photos/4062561/pexels-photo-4062561.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                "https://images.pexels.com/photos/1038916/pexels-photo-1038916.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                "https://images.pexels.com/photos/317385/pexels-photo-317385.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                "https://images.pexels.com/photos/735911/pexels-photo-735911.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                      };

      Random rd = new Random();
      int randomNum = rd.Next(0, 4);



      Event myEvent = new()
      {
        Id = Guid.NewGuid(),
        ImgUrl = pictures[randomNum],
        Name = eventDto.Name,
        Description = eventDto.Description,
        Access = eventDto.Access,
        HostId = eventDto.HostId,
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        HostName = eventDto.HostName,
        EndDateTime = eventDto.EndDateTime,
      };




      //Saving event
      var response = await client.SetTaskAsync("events/" + myEvent.Id, myEvent);
      Event result = response.ResultAs<Event>();






      Console.WriteLine("Pushed new event");

      return result;

    }

    // PUT /events/{id}

    [Authorize]
    [HttpPut("{id}")]

    public async Task<UpdateEventDto> UpdateEvent(String id, UpdateEventDto eventDto)
    {

      UpdateEventDto updatedEvent = new UpdateEventDto
      {
        Location = eventDto.Location,
        Name = eventDto.Name,
        Description = eventDto.Description,
        Access = eventDto.Access,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime


      };

      var response = await client.UpdateTaskAsync("events/" + id, updatedEvent);
      Event result = response.ResultAs<Event>();

      Console.WriteLine("Event's information has been updated.");

      return updatedEvent;

    }

    // DELETE /events/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<String> DeleteEvent(String id)
    {
      var response = await client.DeleteTaskAsync("events/" + id);


      return "This event has been removed.";
    }

     // DELETE /events/{id}
    [HttpDelete]
    
    public async Task<String> SelfDeletedEvents(String id)
    {
      var response = await client.DeleteTaskAsync("events/" + id);


      return "This event has been removed.";
    }


    // POST User into Event
    [Authorize]
    [HttpPost]
    [Route("/addEventToUser/{eventId}/{userId}")]

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
    [Authorize]
    [HttpPost]
    [Route("/addUserToEvent/{eventId}")]
    public async Task<Event> AddUserToEvent(String eventId, [FromBody] string[] userName)
    {




      var existingEvent = await client.GetTaskAsync("events/" + eventId);



      Event myEvent = existingEvent.ResultAs<Event>();


      myEvent.JoinedUsers.Add(userName[0]);
      var rs = await client.SetTaskAsync("events/" + eventId, myEvent);


      return myEvent;


    }

    [HttpPost]
    [Route("/addGuestToEvent/{eventId}")]
    public async Task<Event> Join(String eventId, [FromBody] string[] userName)
    {

      Guest guest = new Guest
      {
        Id = Guid.NewGuid(),
        GuestName = userName[0]


      };

      var existingEvent = await client.GetTaskAsync("events/" + eventId);

      Event myEvent = existingEvent.ResultAs<Event>();


      myEvent.JoinedGuests.Add(guest);
      var rs = await client.SetTaskAsync("events/" + eventId, myEvent);



      return myEvent;



    }



  }






}