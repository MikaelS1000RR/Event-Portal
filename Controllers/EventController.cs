using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_Portal.Controllers
{

  [ApiController]
  [Route("/events")]
  public class EventController : ControllerBase
  {
    private readonly IEventRepo eventControllerRepository;
    private readonly IUserRepo userControllerRepository;
    public EventController(IEventRepo eventControllerRepository, IUserRepo userControllerRepository)
    {
      this.eventControllerRepository = eventControllerRepository;
      this.userControllerRepository = userControllerRepository;
    }

    // GET /events
    [HttpGet]
    public async Task<IEnumerable<EventDto>> GetEvents()
    {
      var events = (await eventControllerRepository.GetEventsAsync())
                   .Select(myEvent => myEvent.AsDto2());
      return events;
    }

    // GET /events/{id}
    [HttpGet("{id}")]

    public async Task <ActionResult<EventDto>> GetEventAsync(Guid id)
    {
      var myEvent = await eventControllerRepository.GetEventAsync(id);

      if (myEvent is null)
      {
        return NotFound();
      }

      return myEvent.AsDto2();
    }

    // POST /events
    [HttpPost]

    public async Task <ActionResult<EventDto>> CreateEventAsync(CreateEventDto eventDto)

    {
      Event myEvent = new()
      {
        Id = Guid.NewGuid(),
        HostId = eventDto.HostId,
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };

     await eventControllerRepository.CreateEventAsync(myEvent);
      User existingUser = await userControllerRepository.GetUserAsync(myEvent.HostId);

      existingUser.CreatedEvents.Add(myEvent);



      return CreatedAtAction(nameof(GetEventAsync), new { id = myEvent.Id }, myEvent.AsDto2());
    }

    // PUT /events/{id}

    [HttpPut("{id}")]

    public async Task <ActionResult> UpdateEvent(Guid id, UpdateEventDto eventDto)
    {
      var existingEvent = await eventControllerRepository.GetEventAsync(id);

      if (existingEvent is null)
      {
        return NotFound();
      }

      Event updatedEvent = existingEvent with
      {
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };

     await eventControllerRepository.UpdateEventAsync(updatedEvent);

      return NoContent();
    }

    // DELETE /events/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEventAsync(Guid id)
    {
      var existingEvent = await eventControllerRepository.GetEventAsync(id);

      if (existingEvent is null)
      {
        return NotFound();
      }

      await eventControllerRepository.DeleteEventAsync(id);

      return NoContent();
    }


    // POST User into Event

    [HttpPost("addEventToUser/{eventId}/{userId}")]

    public async Task <ActionResult<User>> AddEventToUser(Guid eventId, Guid userId)
    {
      var existingEvent = await eventControllerRepository.GetEventAsync(eventId);
      if (existingEvent is null)
      {
        return NotFound();
      }
      User existingUser = await userControllerRepository.GetUserAsync(userId);


      existingUser.JoinedEvents.Add(existingEvent);
     
     
     // existingEvent.JoinedUsers.Add(existingUser)

      return existingUser;
    }

    // Create new Method here

    [HttpPost("addUserToEvent/{userId}/{eventId}")]
    public async Task<ActionResult<Event>> AddUserToEventAsync(Guid userId, Guid eventId) 
    {

      var existingEvent = await eventControllerRepository.GetEventAsync(eventId);
      User existingUser = await userControllerRepository.GetUserAsync(userId);

      if (existingUser is null)
      {
        return NotFound();
      }

      existingEvent.JoinedUsers.Add(existingUser);

      return existingEvent;
    }
    


  }






}