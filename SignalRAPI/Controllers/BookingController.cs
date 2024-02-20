using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.BookingDto;
using SignalRAPI.DAL;
using SignalRAPI.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly SignalRContext _context;

        public BookingController(SignalRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _context.Bookings.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = createBookingDto.Date,
                Mail=createBookingDto.Mail,
                Name=createBookingDto.Name, 
                PersonCount=createBookingDto.PersonCount,
                Phone=createBookingDto.Phone,
   
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok("Başarılı");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Bookings.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Başarılı");
        }

        [HttpPut]
        public IActionResult Update(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId=updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,

            };
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return Ok("Başarılı");
        }

        [HttpGet("GetBooking")]

        public IActionResult GetBooking(int id)
        {
            var value = _context.Bookings.Find(id);

            return Ok(value);

        }
    }
}
