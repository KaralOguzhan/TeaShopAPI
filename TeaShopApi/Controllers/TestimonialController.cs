using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinesLayer.Abstract;
using TeaShopApi.DtoLayer.TestimonialDto;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList() 
        { 
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            
            Testimonial testimonial = new Testimonial()
            {
                TestimonialName = createTestimonialDto.TestimonialName,
                TestimonialComment = createTestimonialDto.TestimonialComment,
                TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
            };
            _testimonialService.TInsert(testimonial);
            return Ok("Referansınız başarı ile eklendi");

        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Referans Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                TestimonialComment = updateTestimonialDto.TestimonialComment,
                TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
                TestimonialName = updateTestimonialDto.TestimonialName
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Güncelleme İşlemi Yapıldı");
        }
    }
}
