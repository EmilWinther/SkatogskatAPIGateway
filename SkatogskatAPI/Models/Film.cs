namespace SkatogskatAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        public int Stars { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
