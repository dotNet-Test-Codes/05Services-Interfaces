using _05Services_Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace _05Services_Interfaces.Data
{
    public class ArticleDBContext : DbContext
    {
        public ArticleDBContext(DbContextOptions<ArticleDBContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
