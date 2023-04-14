using _05Services_Interfaces.Data;
using _05Services_Interfaces.Models;
using _05Services_Interfaces.Services;
using _05Services_Interfaces.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _05Services_Interfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            var articles = _articleService.GetAll();
            if(articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = _articleService.Get(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticles(Article article)
        {
            var art = _articleService.Create(article);
            if(art == null)
            {
                return BadRequest();
            }
            return Ok(art);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateArticles(Article article)
        {
            var art = _articleService.Update(article);
            if (art == null)
            {
                return NotFound();
            }
            
            return Ok(art);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteArticles(int id)
        {
            var art = _articleService.Delete(id);
            if (art == null)
            {
                return NotFound();
            }
            return Ok(art);
        }
    }
}
