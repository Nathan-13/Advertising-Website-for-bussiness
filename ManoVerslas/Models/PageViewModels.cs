using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManoVerslas.Models
{
    public class PageViewModels
    {
        public class Page
        {
            public string Id { get; set; }
            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }
            [Required]
            [Display(Name = "ShortDescription")]
            public string ShortDescription { get; set; }
            [Required]
            [Display(Name = "Body")]
            public string Body { get; set; }
            [Required]
            [Display(Name = "Meta")]
            public string Meta { get; set; }
            [Required]
            [Display(Name = "UrlSeo")]
            public string UrlSeo { get; set; }
            [Required]
            [Display(Name = "User Image")]
            public string UserImage { get; set; }
            [Display(Name = "Experience")]
            public int Exp { get; set; }
            [Display(Name = "Logo")]
            public string Logo { get; set; }
            [Display(Name = "Website URL")]
            public string WebURL { get; set; }
            [Display(Name = "Facebook URL")]
            public string FacebookUrl { get; set; }
            [Display(Name = "Address")]
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string City { get; set; }
            public bool Published { get; set; }
            [DefaultValue(0)]
            public DateTime PostedOn { get; set; }
            public DateTime Modified { get; set; }
            public ParentCategory PCategory { get; set; }
            public ChildCategory CCategory { get; set; }

            // public ICollection<ChildCategory> ChildCategories { get; set; }
            public ICollection<PageImage> PageImages { get; set; }
            public ICollection<PageStar> PageStars { get; set; }

        }

        public class ParentCategory
        {

            public string Id { get; set; }
            [Required]
            [Display(Name = "Parent Category Name")]
            public string PCatName { get; set; }
            [Required]
            [Display(Name = "NumberOfPages")]
            public int NumberOfPages { get; set; }
            [Required]
            [Display(Name = "UrlSeo")]
            public string UrlSeo { get; set; }
            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            public ICollection<ChildCategory> ChildCategories { get; set; }

            //  public Page Page { get; set; }

        }

        public class ChildCategory
        {


            [Key]
            [Column(Order = 0)]
            public string PageId { get; set; }

            [Key]
            [Column(Order = 1)]
            public string ParentCategoryId { get; set; }

            [Required]
            [Display(Name = "Child Category Name")]
            public string CCatName { get; set; }
            [Required]
            [Display(Name = "NumberOfPages")]
            public int NumberOfPages { get; set; }
            [Required]
            [Display(Name = "UrlSeo")]
            public string UrlSeo { get; set; }
            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }
            //public ParentCategory ParentCategory { get; set; }
            // public Page Page { get; set; }
            public ICollection<Page> Pages { get; set; }
        }

        public class PageImage
        {
            public int Id { get; set; }
            [Required]
            [Display(Name = "ImageUrl")]
            public string ImageUrl { get; set; }
            public string PageId { get; set; }
            public string ImageName { get; set; }

            public Page Page { get; set; }

        }

        public class PageStar
        {
            [Key]
            public string PageId { get; set; }
            public bool StarNumberPlus { get; set; }
            public bool StarNumberMinus { get; set; }

            public Page Page { get; set; }
        }

        public class PageViewModel
        {
            internal object ChildCategories;

            public DateTime PostedOn { get; set; }
            public DateTime Modified { get; set; }
            public bool StarNumberPlus { get; set; }
            public bool StarNumberMinus { get; set; }
            public List<string> ParentCategory { get; set; }
            public List<string> ChildCategory { get; set; }
            public int NumberOfPages { get; set; }
            public Page Page { get; set; }
            public string ID { get; set; }
            public string ShortDescription { get; set; }
            public string Title { get; set; }
            public string Meta { get; set; }
            public string Body { get; set; }
            public string UrlSeo { get; set; }
            public string UserImage { get; set; }
            public int Exp { get; set; }
            public string Logo { get; set; }
            public string WebURL { get; set; }
            public string FacebookUrl { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public object PageStars { get; internal set; }
            public string UserName { get; internal set; }
            public string Email { get; internal set; }
            public string PhoneNumber { get; internal set; }
            public object PageImages { get; internal set; }
        }
        public class AllPagesViewModel
        {
            public IList<ParentCategory> PageParentCategories { get; set; }
            public IList<ChildCategory> PageChildCategories { get; set; }
            public string PageId { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public string Title { get; set; }
            public ParentCategory ParentCategory { get; set; }
            public ChildCategory ChildCategory { get; set; }
            public bool Checked { get; set; }
            public string UrlSlug { get; set; }
        }

        public class UserPageViewModel
        {
            public string Body { get; set; }
            public string FirstPageId { get; set; }
            public string ID { get; set; }
            public string LastPageId { get; set; }
            public string NextPageSlug { get; set; }
            public int PageCount { get; set; }
            public string PreviousPageSlug { get; set; }

            public string UserName { get; set; }
            public string UserImage { get; set; }
            public IList<PageImage> Images { get; set; }
            public string City { get; set; }
            public int Exp { get; set; }
            public string Meta { get; set; }
            public string UrlSeo { get; set; }
            public IList<ParentCategory> ChildCategories { get; set; }
            public string ShortDescription { get; set; }
            public IList<ParentCategory> ParentCategories { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Logo { get; set; }
            public string WebURL { get; set; }
            public string FacebookUrl { get; set; }

        }
        public class PagesListViewModel
        {
            public IEnumerable<Page> Pages { get; set; }
            public IEnumerable<ParentCategory> ParentCategories { get; set; }
            public IEnumerable<ChildCategory> ChildCategories { get; set; }
        }

    }
}