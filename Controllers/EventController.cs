using System;
using System.Collections.Generic;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_Portal.Controllers
{

    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
    private readonly EventRepo repository;

    public EventController()
    {
      repository = new EventRepo();
    }

    // GET /events
    [HttpGet]
    public IEnumerable<Event> GetEvents() 
    {
      var events = repository.GetEvents();
      return events; 
    }

    // GET /events/{id}
    [HttpGet("{id}")]

    public ActionResult<Event> GetEvent(Guid id) 
    {
        var myEvent = repository.GetEvent(id);

        if(myEvent is null) 
        {
        return NotFound();
      }

        return myEvent;
    }

  }
}