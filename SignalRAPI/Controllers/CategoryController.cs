using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.CategoryDto;
using SignalRAPI.DAL;
using SignalRAPI.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SignalRContext _context;
        private readonly IMapper _mapper;

        public CategoryController(SignalRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values =_mapper.Map<List<ResultCategoryDto>>(_context.Categories.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {

            _context.Categories.Add(new Category()
            {
                Name = createCategoryDto.Name,   
                Status=createCategoryDto.Status,
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
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            _context.Categories.Update(new Category()
            {
                CategoryId = updateCategoryDto.CategoryId,
                Name = updateCategoryDto.Name,
                Status = updateCategoryDto.Status,
            });

            _context.SaveChanges();
            return Ok("Güncellendi");

            
        }

        [HttpGet("GetCategory")]

        public IActionResult GetCategory(int id)
        {
            var entity = _context.Categories.Find(id);
            var values = _mapper.Map<GetCategoryDto>(entity);

            return Ok(values);

        }
    }
}
