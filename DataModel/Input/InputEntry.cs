namespace DataModel.Input
{
    public class InputEntry
    {
        public int Id { get; set; }
        public bool IsBuy { get; set; }
        public bool IsMarket { get; set; }
        public long Volume { get; set; }
        public long Value { get; set; }
    }
}