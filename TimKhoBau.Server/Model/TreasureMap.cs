namespace TimKhoBau.Server.Model
{
    public class TreasureMap
    {
        public int Id { get; set; }
        public int n { get; set; }
        public int m { get; set; }
        public int P { get; set; }
        public string Matrix { get; set; } // Store as JSON string
    }
}
