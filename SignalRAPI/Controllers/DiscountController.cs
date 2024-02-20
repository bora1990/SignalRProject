using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.DiscountDto;
using SignalRAPI.DAL;
using SignalRAPI.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly SignalRContext _context;
        private readonly IMapper _mapper;

        public DiscountController(SignalRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_context.Discounts.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            _context.Discounts.Add(new Discount()
            {
             Description = createDiscountDto.Description,
             Amount=createDiscountDto.Amount,
             ImageUrl = createDiscountDto.ImageUrl,
             Title = createDiscountDto.Title,   
            });
            _context.SaveChanges();
            return Ok("Eklendi");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Başarılı");
        }

        [HttpPut]
        public IActionResult Update(UpdateDiscountDto updateDiscountDto)
        {
            _context.Discounts.Add(new Discount()
            {
                Description = updateDiscountDto.Description,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,
      
            });

            _context.SaveChanges();
            return Ok("Güncellendi");


        }

        [HttpGet("GetDiscount")]

        public IActionResult GetDiscount(int id)
        {
            var entity = _context.Categories.Find(id);
            var values = _mapper.Map<GetDiscountDto>(entity);

            return Ok(values);

        }
    }
}
