using System;
using System.Collections.Generic;
using System.Linq;
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
    public IEnumerable<EventDto> GetEvents() 
    {
      var events = eventControllerRepository.GetEvents().Select( myEvent => myEvent.AsDto2());
      return events; 
    }

    // GET /events/{id}
    [HttpGet("{id}")]

    public ActionResult<EventDto> GetEvent(Guid id) 
    {
        var myEvent = eventControllerRepository.GetEvent(id);

        if(myEvent is null) 
        {
        return NotFound();
      }

        return myEvent.AsDto2();
    }

    // POST /events
    [HttpPost]

    public ActionResult<EventDto> CreateEvent(CreateEventDto eventDto)

    {
      Event myEvent = new()
      {
        Id = Guid.NewGuid(),
        HostId = eventDto.HostId,
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };

      eventControllerRepository.CreateEvent(myEvent);
      User existingUser = userControllerRepository.GetUser(myEvent.HostId);

      existingUser.CreatedEvents.Add(myEvent);



      return CreatedAtAction(nameof(GetEvent), new { id = myEvent.Id }, myEvent.AsDto2());
    }

      // PUT /events/{id}

      [HttpPut("{id}")]

      public ActionResult UpdateEvent(Guid id, UpdateEventDto eventDto) 
      {
      var existingEvent = eventControllerRepository.GetEvent(id);

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

      eventControllerRepository.UpdateEvent(updatedEvent);

      return NoContent();
    }

    // DELETE /events/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(Guid id)
    {
      var existingEvent = eventControllerRepository.GetEvent(id);

      if (existingEvent is null)
      {
        return NotFound();
      }

      eventControllerRepository.DeleteItem(id);

      return NoContent();
    }


    // POST User into Event

    [HttpPost("{userId}/{eventId}")]

    public ActionResult<User> JoinEvent(Guid userId, Guid eventId) 
    {
      var existingEvent = eventControllerRepository.GetEvent(eventId);
      if (existingEvent is null)
      {
        return NotFound();
      }
      User existingUser = userControllerRepository.GetUser(userId);


      existingUser.JoinedEvents.Add(existingEvent);
      existingEvent.JoinedUsers.Add(existingUser);
    

      return existingUser;
    }


        
  }
  
}