using System;
using System.Collections.Generic;
using System.Linq;
using Event_Portal.Dtos;
using Event_Portal.Models;
using Event_Portal.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_Portal.Repositories
{

  [ApiController]

   [Route("/")]
  public class SharedController:ControllerBase
  {
       private readonly IUserRepo userRepository;
       private readonly IEventRepo eventRepository;

       public SharedController (IUserRepo userRepository, IEventRepo eventRepository)
       {
      this.userRepository = userRepository;
      this.eventRepository = eventRepository;
    }



      [HttpGet("createEvent/{userId}")]
    public ActionResult<User> GetUser(Guid userId, [FromBody] string eventId) 
    {
      var existingUser = userRepository.GetUser(userId);
      var existingEvent = eventRepository.GetEvent(Guid.Parse(eventId));

      existingUser.CreatedEvents.Add(existingEvent);

      return existingUser;
    }
  }
  
}