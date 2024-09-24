using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SonaHotel.Models;
using System.Security.Cryptography.X509Certificates;

namespace SonaHotel.Controllers
{
    public class SonaHotelController : Controller
    {
        [HttpGet]
        public IActionResult SearchHotel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchHotel(BookingHotelSearchViewModel bookingHotelSearchViewModel)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={Uri.EscapeDataString(bookingHotelSearchViewModel.cityName)}")
,
                Headers =
    {
       { "x-rapidapi-key", "e1e2d5a204msha771be6eb389b56p1c5c21jsne2e466ab5c39" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BookingHotelDestinationViewModel>(body);
                var cityId = value.data[0].dest_id;
                var getSearch = new BookingHotelSearchViewModel
                {
                    destId = cityId,
                    cityName = bookingHotelSearchViewModel.cityName,
                    arrivalDate = bookingHotelSearchViewModel.arrivalDate,
                    departureDate = bookingHotelSearchViewModel.departureDate,
                    adultCount = bookingHotelSearchViewModel.adultCount,
                    roomCount = bookingHotelSearchViewModel.roomCount
                };
                return RedirectToAction("HotelList", getSearch);
            }
        }
        public async Task<IActionResult> HotelList(BookingHotelSearchViewModel bookingHotelSearchViewModel)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={bookingHotelSearchViewModel.destId}&search_type=CITY&arrival_date={bookingHotelSearchViewModel.arrivalDate:yyyy-MM-dd}&departure_date={bookingHotelSearchViewModel.departureDate:yyyy-MM-dd}&adults={bookingHotelSearchViewModel.adultCount}&children_age=0%2C17&room_qty={bookingHotelSearchViewModel.roomCount}&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR"),


                Headers =
    {
        { "x-rapidapi-key", "e1e2d5a204msha771be6eb389b56p1c5c21jsne2e466ab5c39" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingHotelListViewModel>(body);
                TempData["Photo"] = values.data.hotels[0].property.photoUrls[0].Replace("square60", "square480");
                return View(values.data.hotels.ToList());
            }
          
        }
        [HttpPost]
        public async Task< IActionResult> GetHotelDetail(string hotelId, string departureDate, string arrivalDate)
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id=" + hotelId + "&arrival_date=" + arrivalDate + "&departure_date=" + departureDate + "&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
       { "x-rapidapi-key", "e1e2d5a204msha771be6eb389b56p1c5c21jsne2e466ab5c39" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<BookingHotelDetailViewModel>(body);
                return View(value.data);
            }
        }
    }
}