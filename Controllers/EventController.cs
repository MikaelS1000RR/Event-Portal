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
    private readonly IEventRepo repository;

    public EventController(IEventRepo repository)
    {
      this.repository = repository;
    }

    // GET /events
    [HttpGet]
    public IEnumerable<EventDto> GetEvents() 
    {
      var events = repository.GetEvents().Select( myEvent => myEvent.AsDto2());
      return events; 
    }

    // GET /events/{id}
    [HttpGet("{id}")]

    public ActionResult<EventDto> GetEvent(Guid id) 
    {
        var myEvent = repository.GetEvent(id);

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
        Location = eventDto.Location,
        StartDateTime = eventDto.StartDateTime,
        EndDateTime = eventDto.EndDateTime,
      };

      repository.CreateEvent(myEvent);

      return CreatedAtAction(nameof(GetEvent), new { id = myEvent.Id }, myEvent.AsDto2());
    }

      // PUT /events/{id}

      [HttpPut("{id}")]

      public ActionResult UpdateEvent(Guid id, UpdateEventDto eventDto) 
      {
      var existingEvent = repository.GetEvent(id);

      if (existingEvent is null) 
      { 
        return NotFound();
      }

      Event updatedEvent = existingEvent with
      {
        Location = eventDto.Location
      };

      repository.UpdateEvent(updatedEvent);

      return NoContent();
    }

    // DELETE /events/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(Guid id)
    {
      var existingEvent = repository.GetEvent(id);

      if (existingEvent is null)
      {
        return NotFound();
      }

      repository.DeleteItem(id);

      return NoContent();
    }

  }
}