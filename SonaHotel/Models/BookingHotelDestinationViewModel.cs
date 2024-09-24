namespace SonaHotel.Models
{
    public class BookingHotelDestinationViewModel
    {
        public Data[] data { get; set; }

        public class Data
        {
            public string dest_id { get; set; }
        }
    }
}
