namespace Event_Portal.Models
{
  public class Event
  {


    private int id { get; set; }
    public string location { get; set; }

    public string startDate { get; set; }

    public string endDate { get; set; }

    private string startTime { get; set; }
    private string endTime { get; set; }

    private int hostId { get; set; }

    public User[] userInvitedList { get; set; }

    public Event(
        int id, string location, string startDate, string endDate,
        string startTime, string endTime, int hostId
    )
    {
      this.id = id;
      this.location = location;
      this.startDate = startDate;
      this.endDate = endDate;
      this.startTime = startTime;
      this.endTime = endTime;
      this.hostId = hostId;
    }

  }
}