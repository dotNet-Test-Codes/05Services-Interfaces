using _05Services_Interfaces.Models;

namespace _05Services_Interfaces.Services.Interfaces
{
    public interface IArticleService
    {
        List<Article> GetAll();
        Article Get(int id);
        Article Create(Article article);
        Article Update(Article article);
        Article Delete(Article article);
        void Save();
    }
}
