namespace GameStop.Models 

{
    public class VideoGame 
    {
        public int VideoGameId { get; set; }

        public string Name { get; set; }

        public int GamerId { get; set; }

        public Gamer Gamer { get; set; }

        public List<VideoGameTag> JoinEntities { get;}

        public ApplicationUser User { get; set; }
    }

}