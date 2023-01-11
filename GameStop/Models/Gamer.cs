namespace GameStop.Models 

{
    public class Gamer 
    {
        public int GamerId { get; set; }
        
        public string Name { get; set; }

        public List<VideoGame> VideoGames { get; set; }
    }

}