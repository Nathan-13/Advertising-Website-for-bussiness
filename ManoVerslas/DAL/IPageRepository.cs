using ManoVerslas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManoVerslas.Models.PageViewModels;

namespace ManoVerslas.DAL
{
    public interface IPageRepository : IDisposable
    {

        #region 1
        IList<Page> GetPages();
        //IList<ParentCategory> GetChildCategories(Page page);
        // IList<PageViewModels.PageImage> GetPageImage(PageViewModels.Page page);
        IList<PageImage> GetPageImages(Page page);
        int StarCount(string Star, string id);
        IList<ParentCategory> GetParentCategoriesList();
        IList<ChildCategory> GetChildCategoriesList();
        IList<ParentCategory> GetParentCategoriesList2();
        #endregion

        Page GetPageById(string id);
        string GetPagesIdBySlug(string slug);

        void Save();

        void AddImageToPage(string pageid, string ImageUrl);
        void RemoveImageFromPage(string pageid, string ImageUrl);
    }
}