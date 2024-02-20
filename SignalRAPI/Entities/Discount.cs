namespace SignalRAPI.Entities
{
    public class Discount  
    {
        public int DiscountId { get; set; }

        public string Title { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }  //off açıklama

        public string ImageUrl { get; set; }
    }
}
