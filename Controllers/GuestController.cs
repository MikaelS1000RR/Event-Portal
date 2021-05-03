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
  [Route("/join-event")]
    public class GuestController : ControllerBase
    {

    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "JVGSRZVMU5Iw6TtGygVyEPUf41Zk40viN3UxWR76",
      BasePath = "https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/"
    };

    IFirebaseClient client;



    public GuestController()
    {


      client = new FireSharp.FirebaseClient(config);
    }

    [HttpPost]

    public async Task<Guest> CreateGuest (CreateGuestDto guestDto) {

      Guest guest = new()
      {
        Id = Guid.NewGuid(),
        GuestName = guestDto.GuestName
      };

      FirebaseResponse res = client.Get(@"users/" + guest.GuestName);
      Event myEvent = JsonConvert.DeserializeObject<Event>(res.Body.ToString());



        if(myEvent != null)
        {
        var response = await client.SetTaskAsync("users/" + guest.GuestName, guest);
        User result = response.ResultAs<User>();

        myEvent.JoinedUsers.Add(result);

        var rs = await client.SetTaskAsync 
        ("users/" + guest.GuestName, myEvent);


        Console.WriteLine("Added new guest");


        return result;
      }
      else
      {
        Console.WriteLine("Error");
        return null;
      }

    }

    }
}