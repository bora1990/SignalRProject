using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.AboutDto;
using SignalRAPI.DAL;
using SignalRAPI.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly SignalRContext _context;

        public AboutController(SignalRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values=_context.Abouts.ToList();
            return Ok(values);
        }
        [HttpPost]  
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,

            };
            _context.Abouts.Add(about);
            _context.SaveChanges(); 

            return Ok("Başarılı");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return Ok("Başarılı");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId=updateAboutDto.AboutID,
                Description = updateAboutDto.Description,
                Title = updateAboutDto.Title,
                ImageUrl = updateAboutDto.ImageUrl
            };
            _context.Abouts.Update(about);
            _context.SaveChanges(); 
            return Ok("Başarılı");
        }

        [HttpGet("GetAbout")]

        public IActionResult GetAbout(int id) 
        {
            var value=_context.Abouts.Find(id);
            
            return Ok(value);
        
        }
    }
}
