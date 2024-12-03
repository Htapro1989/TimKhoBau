namespace TimKhoBau.Server.Model
{
    public class TreasureMap
    {
        public int Id { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int P { get; set; }
        public string Matrix { get; set; } // Store as JSON string
    }
}
