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
        public List<Article> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
