using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ManoVerslas.DAL;
using ManoVerslas.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
//using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ManoVerslas.Models.PageViewModels;
using System.Data.Entity.Validation;

namespace ManoVerslas.Controllers
{
    public class PageController : Controller
    {
        PageDbContext context = new PageDbContext();
        private IPageRepository _pageRepository;
        public static List<PageViewModel> pageList = new List<PageViewModel>();
        public static List<AllPagesViewModel> AllPagesList = new List<AllPagesViewModel>();
        public static List<AllPagesViewModel> CheckChildCategory = new List<AllPagesViewModel>();
        public static List<AllPagesViewModel> CheckParentCategory = new List<AllPagesViewModel>();


        public PageController()
        {
            _pageRepository = new PageRepository(new PageDbContext());
        }

        public PageController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;


        }
        [HttpGet]
        [AllowAnonymous]
        // GET: Page
        public ActionResult Index(int? psl, string searchString)/*, string[] searchParentCategory, string[] searchChildCategory)*/
        {
            Pages(psl, searchString); /*, searchParentCategory, searchChildCategory);*/
            return View();

        }

      // [ChildActionOnly]
        public ActionResult Pages(int? psl, string searchString)/*, string[] searchParentCategory, string[] searchChildCategory*/
        {
            pageList.Clear();

            ViewBag.CurrentSearchString = searchString;

            var pages = _pageRepository.GetPages();
            foreach (var page in pages)
            {


                //var childCategories = GetChildCategories(page);
                pageList.Add(new PageViewModel()
                {
                    Page = page,
                    UserImage = page.UserImage,
                    ShortDescription = page.ShortDescription,
                    ID = page.Id,
                    City = page.City,
                    //  ChildCategories = childCategories,
                    UserName = page.UserName,
                    Email = page.Email,
                    PhoneNumber = page.PhoneNumber,
                    PageImages = page.PageImages,
                    UrlSeo = page.UrlSeo,
                    Address = page.Address

                });

            }


            if (searchString != null)
            {
                pageList = pageList.Where(x => x.ShortDescription.ToLower().Contains(searchString.ToLower())).ToList();
            }

            //if (searchParentCategory != null)
            //{
            //    List<PageViewModel> newlist = new List<PageViewModel>();
            //    foreach (var catName in searchParentCategory)
            //    {
            //        foreach (var item in pageList)
            //        {
            //            if (item.ChildCategories.Where(x => p.PCatName == catName).Any())
            //            {
            //                newlist.Add(item);
            //            }
            //        }
            //        foreach (var item in CheckParentCategory)
            //        {
            //            if (item.ParentCategory.PCatName == catName)
            //            {
            //                item.Checked = true;
            //            }
            //        }
            //    }
            //    pageList = pageList.Intersect(newlist).ToList();
            //}

            //if (searchChildCategory != null)
            //{
            //    List<PageViewModel> newlist = new List<PageViewModel>();
            //    foreach (var ChildCatName in searchChildCategory)
            //    {
            //        foreach (var item in pageList)
            //        {
            //            if (item.PostTags.Where(x => x.CCatName == ChildCatName).Any())
            //            {
            //                newlist.Add(item);
            //            }
            //        }
            //        foreach (var item in CheckChildCategory)
            //        {
            //            if (item.ChildCategory.CCatName == ChildCatName)
            //            {
            //                item.Checked = true;
            //            }
            //        }
            //    }
            //    pageList = pageList.Intersect(newlist).ToList();
            //}

            int pageSize = 2;
            int pageNumber = (psl ?? 1);

            return PartialView("Pages", pageList.ToPagedList(pageNumber, pageSize));

        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserPage(string slug)
        {
            UserPageViewModel model = new UserPageViewModel();
            var pages = GetPages();
            var pageid = _pageRepository.GetPagesIdBySlug(slug);
            var page = _pageRepository.GetPageById(pageid);
            var Images = GetPageImages(page);
            var firstPageId = pages.OrderBy(i => i.PostedOn).First().Id;
            var lastPageId = pages.OrderBy(i => i.PostedOn).Last().Id;
            var nextId = pages.OrderBy(i => i.PostedOn).SkipWhile(i => i.Id != pageid).Skip(1).Select(i => i.Id).FirstOrDefault();
            var previousId = pages.OrderBy(i => i.PostedOn).TakeWhile(i => i.Id != pageid).Select(i => i.Id).LastOrDefault();
            model.FirstPageId = firstPageId;
            model.LastPageId = lastPageId;
            model.PreviousPageSlug = pages.Where(x => x.Id == previousId).Select(x => x.UrlSeo).FirstOrDefault();
            model.NextPageSlug = pages.Where(x => x.Id == nextId).Select(x => x.UrlSeo).FirstOrDefault();
            model.ID = page.Id;
            model.PageCount = pages.Count();
            model.UrlSeo = page.UrlSeo;
            model.Images = Images;
            model.UserName = page.UserName;
            model.UserImage = page.UserImage;
            model.City = page.City;
            model.Body = page.Body;
            model.Exp = page.Exp;
            model.Email = page.Email;
            model.Address = page.Address;
            model.PhoneNumber = page.PhoneNumber;


            return View(model);
        }


        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPage(string slug)
        {
            var model = CreatePageViewModel(slug);
            return View(model);
        }


       // [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditPage(UserPageViewModel model)
        {
            var page = _pageRepository.GetPageById(model.ID);
            page.UserName = model.UserName;
            page.ShortDescription = model.ShortDescription;
            page.Body = model.Body;
            page.Meta = model.Meta;
            page.UrlSeo = model.UrlSeo;
            page.UserImage = model.UserImage;
            page.Logo = model.Logo;
            page.WebURL = model.WebURL;
            page.FacebookUrl = model.FacebookUrl;
            page.Address = model.Address;
            page.Email = model.Email;
            page.PhoneNumber = model.PhoneNumber;
            page.City = model.City;
            page.Modified = DateTime.Now;
            //  _pageRepository.Save();
            try
            {
                _pageRepository.Save();
                
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                
            }

            return RedirectToAction("UserPage", new { slug = model.UrlSeo });
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddImageToPage(string pageid, string slug)
        {
            UserPageViewModel model = new UserPageViewModel();
            model.ID = pageid;
            model.UrlSeo = slug;
            return View(model);
        }


        // [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImageToPage(string pageid, string slug, string ImageUrl)
        {
            CreatePageViewModel(slug);
            _pageRepository.AddImageToPage(pageid, ImageUrl);
            return RedirectToAction("EditPage", new { slug = slug });
        }


        // [Authorize(Roles = "Admin")]
        public ActionResult RemoveImageFromPage(string slug, string pageid, string ImageUrl)
        {
            CreatePageViewModel(slug);
            _pageRepository.RemoveImageFromPage(pageid, ImageUrl);
            return RedirectToAction("EditPage", new { slug = slug });
        }


        public ActionResult ParentCategoriesList()
        {
            var query = _pageRepository.GetParentCategoriesList();
            return PartialView("_ParentCategories", query);
        }

        public ActionResult ParentCategoriesList2()
        {
            ParentCategory model = new ParentCategory();
            var query = _pageRepository.GetParentCategoriesList2();
        
            return PartialView("_ParentCategories");
        }

























        #region Helpers
        //private object GetChildCategories(PageViewModels.Page page)
        //{
        //    return _pageRepository.GetChildCategories(page);
        //}

        public IList<PageViewModels.Page> GetPages()
        {
            return _pageRepository.GetPages();
        }
        public IList<ParentCategory> GetParentCategoriesList()
        {
            return _pageRepository.GetParentCategoriesList();
        }
        public IList<ParentCategory> GetParentCategoriesList2()
        {
            return _pageRepository.GetParentCategoriesList2();
        }

        public IList<PageImage> GetPageImages(Page page)
        {
            return _pageRepository.GetPageImages(page);
        }
        public void CreatePCatAndCCatList()
        {
            foreach (var PCat in _pageRepository.GetParentCategoriesList())
            {
                CheckParentCategory.Add(new AllPagesViewModel { ParentCategory = PCat, Checked = false });
            }
            foreach (var CCat in _pageRepository.GetChildCategoriesList())
            {
                CheckChildCategory.Add(new AllPagesViewModel { ChildCategory = CCat, Checked = false });
            }
        }

        public UserPageViewModel CreatePageViewModel(string slug)
        {
            UserPageViewModel model = new UserPageViewModel();
            var pageid = _pageRepository.GetPagesIdBySlug(slug);
            var page = _pageRepository.GetPageById(pageid);
            model.ID = pageid;
            model.UserName = page.UserName;
            model.ShortDescription = page.ShortDescription;
            model.Body = page.Body;
            model.Meta = page.Meta;
            model.UrlSeo = page.UrlSeo;
            model.UserImage = page.UserImage;
            model.Logo = page.Logo;
            model.WebURL = page.WebURL;
            model.FacebookUrl = page.FacebookUrl;
            model.Address = page.Address;
            model.Email = page.Email;
            model.PhoneNumber = page.PhoneNumber;
            model.City = page.City;
            model.Images = _pageRepository.GetPageImages(page).ToList();
            //  model.ChildCategories = _pageRepository.GetChildCategories(page).ToList();
            return model;
        }
        #endregion






    }
}