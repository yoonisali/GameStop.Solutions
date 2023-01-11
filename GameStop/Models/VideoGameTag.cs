namespace GameStop.Models
{
  public class VideoGameTag
    {       
        public int VideoGameTagId { get; set; }
        public int VideoGameId { get; set; }
        public VideoGame VideoGame { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}