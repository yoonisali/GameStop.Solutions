namespace GameStop.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        public string Title { get; set; }
        public List<VideoGameTag> JoinEntities { get;}
    }
}