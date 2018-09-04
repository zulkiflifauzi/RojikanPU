using RojikanPU.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RojikanPU.Repositories.Interfaces
{
    public interface IArticleFileRepository : IBaseRepository<ArticleFile>
    {
        List<ArticleFile> GetArticleFiles(int articleId);
    }
}
