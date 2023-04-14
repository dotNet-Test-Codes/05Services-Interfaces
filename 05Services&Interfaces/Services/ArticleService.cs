using _05Services_Interfaces.Data;
using _05Services_Interfaces.Models;
using _05Services_Interfaces.Services.Interfaces;

namespace _05Services_Interfaces.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ArticleDBContext _context;
        public ArticleService(ArticleDBContext context)
        {
            _context = context;
        }

        public Article Create(Article article)
        {
            throw new NotImplementedException();
        }

        public Article Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public Article Get(int id) => this.GetByID(id);

        public List<Article> GetAll()
        {
            var articles = _context.Articles.ToList();
            return articles;
        }

        public Article Update(Article article)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private Article GetByID(int id) => _context.Articles.Where(a => a.ID == id).FirstOrDefault();
    }
}
