using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinesLayer.Abstract;
using TeaShopApi.DtoLayer.QuestionDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult QuestionList()
        {
            var values = _questionService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            Question question = new Question()
            {
                AnswerDetail = createQuestionDto.AnswerDetail,
                QuestionDetail = createQuestionDto.QuestionDetail
            };
            _questionService.TInsert(question);
            return Ok("Soru başarılı şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            var values = _questionService.TGetById(id);
            _questionService.TDelete(values);
            return Ok("Soru başarı ile silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            var values = _questionService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            Question question = new Question()
            {
                AnswerDetail = updateQuestionDto.AnswerDetail,
                QuestionDetail = updateQuestionDto.QuestionDetail,
                QuestionID = updateQuestionDto.QuestionID
            };
            _questionService.TUpdate(question);
            return Ok("Güncelleme işlemi yapıldı");
        }
    }
}
