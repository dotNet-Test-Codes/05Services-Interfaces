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
        private readonly ArticleDBContext _context;
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService, ArticleDBContext context)
        {
            _articleService = articleService;
            _context = context;
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
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return Ok(article);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateArticles(Article article)
        {
            var art = this.GetArticle(article.ID);
            if (art != null)
            {
                art.ID = article.ID;
                art.Name = article.Name;
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return Ok(art);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteArticles(int id)
        {
            var art = await _context.Articles.Where(a => a.ID == id).FirstOrDefaultAsync();
            if (art != null)
            {
                _context.Articles.Remove(art);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return Ok(art);
        }

        private Article GetArticle(int id)
        {
            var article = _context.Articles.Where(a => a.ID == id).FirstOrDefault();

            return article;
        }
    }
}
