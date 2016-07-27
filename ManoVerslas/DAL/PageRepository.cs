using ManoVerslas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ManoVerslas.Models.PageViewModels;

namespace ManoVerslas.DAL
{
    public class PageRepository : IPageRepository, IDisposable
    {
        private PageDbContext _context;
        public PageRepository(PageDbContext context)
        {
            _context = context;
        }

        #region 1
        public IList<Page> GetPages()
        {
            return _context.Pages.ToList();
        }


        public IList<ParentCategory> GetParentCategoriesList()
        {
            return _context.ParentCategories.ToList();
        }

        public IList<ParentCategory> GetParentCategoriesList2()
        {
            return _context.ParentCategories.Where(category => category.Id == null)
                            .Include(category => category.ChildCategories).ToList();
        }




        public IList<ChildCategory> GetChildCategoriesList()
        {
            return _context.ChildCategories.ToList();
        }


        public IList<ParentCategory> GetChildCategories(Page page)
        {

            var categoryIds = _context.ChildCategories.Where(p => p.PageId == page.Id).Select(p => p.ParentCategoryId).ToList();
            List<ParentCategory> parentcategories = new List<ParentCategory>();
            foreach (var catId in categoryIds)
            {
                parentcategories.Add(_context.ParentCategories.Where(p => p.Id == catId).FirstOrDefault());
            }
            return parentcategories;


        }

        public IList<PageImage> GetPageImages(Page page)
        {
            var pageUrls = _context.PageImages.Where(p => p.PageId == page.Id).ToList();
            List<PageImage> images = new List<PageImage>();
            foreach (var url in pageUrls)
            {
                images.Add(url);
            }
            return images;
        }

        public int StarCount(string Star, string id)
        {
            switch (Star)
            {
                case "pagestarplus":
                    return _context.PageStars.Where(p => p.PageId == id && p.StarNumberPlus == true).Count();
                case "pagestarminus":
                    return _context.PageStars.Where(p => p.PageId == id && p.StarNumberMinus == true).Count();
                default:
                    return 0;
            }
        }

        public void AddImageToPage(string pageid, string ImageUrl)
        {
            List<int> numlist = new List<int>();
            int num = 1;
            string imageName = null;
            var check = _context.PageImages.Where(x => x.PageId == pageid && x.ImageUrl == ImageUrl).Any();
            if (!check)
            {
                while (_context.PageImages.Where(x => x.Id == num).Any())
                {
                    num++;
                }
                //if (ImageUrl.Contains(".jpg") || ImageUrl.Contains(".png"))
                //{
                //    int pos = ImageUrl.LastIndexOf("/") + 1;
                //    var result = ImageUrl.Substring(pos, ImageUrl.Length - pos);
                //    thumbUrl = "" + result + "/0.jpg";
                //    siteName = "YouTube";
                //}
                var image = new PageImage { Id = num, PageId = pageid, ImageUrl = ImageUrl, ImageName = imageName };
                _context.PageImages.Add(image);
                Save();
            }

        }
        public void RemoveImageFromPage(string pageid, string ImageUrl)
        {
            var image = _context.PageImages.Where(x => x.PageId == pageid && x.ImageUrl == ImageUrl).FirstOrDefault();
            _context.PageImages.Remove(image);
            Save();
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        #endregion
        public Page GetPageById(string id)
        {
            return _context.Pages.Find(id);
        }
        public string GetPagesIdBySlug(string slug)
        {
            return _context.Pages.Where(x => x.UrlSeo == slug).FirstOrDefault().Id;
        }

        #region 2











        #endregion

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

}