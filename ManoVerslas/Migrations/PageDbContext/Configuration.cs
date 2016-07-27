namespace ManoVerslas.Migrations.PageDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManoVerslas.Models.PageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PageDbContext";
        }

        protected override void Seed(ManoVerslas.Models.PageDbContext context)
        {
            ////context.Pages.AddOrUpdate(new Models.PageViewModels.Page { Id = "1", UserName = "Lorem", ShortDescription = "Lorem", Body = "Lorem Category", Meta = "cat1", UrlSeo = "Lorem", UserImage = "~/Image/User/000001.png", Exp = 5, Logo = "~/Image/Logo/000001.png", WebURL = "Lorem", FacebookUrl = "Lorem", Address = "Lorem Categ", Email = "Lorem", PhoneNumber = "Lorem", City = "Lorem Category", Published = true, PostedOn = DateTime.Now });
            ////context.Pages.AddOrUpdate(new Models.PageViewModels.Page { Id = "2", UserName = "Lorem2", ShortDescription = "Lorem", Body = "Lorem Category", Meta = "cat2", UrlSeo = "Lorem", UserImage = "~/Image/User/000002.png", Exp = 2, Logo = "~/Image/Logo/000002.jpg", WebURL = "Lorem", FacebookUrl = "Lorem", Address = "Lorem Categ", Email = "Lorem", PhoneNumber = "Lorem", City = "Lorem Category", Published = true, PostedOn = DateTime.Now });
            ////context.Pages.AddOrUpdate(new Models.PageViewModels.Page { Id = "3", UserName = "Lorem3", ShortDescription = "Lorem", Body = "Lorem Category", Meta = "cat3", UrlSeo = "Lorem", UserImage = "~/Image/User/000003.png", Exp = 1, Logo = "~/Image/Logo/000003.png", WebURL = "Lorem", FacebookUrl = "Lorem", Address = "Lorem Categ", Email = "Lorem", PhoneNumber = "Lorem", City = "Lorem Category", Published = true, PostedOn = DateTime.Now });
            ////context.Pages.AddOrUpdate(new Models.PageViewModels.Page { Id = "4", UserName = "Lorem4", ShortDescription = "Lorem", Body = "Lorem Category", Meta = "cat4", UrlSeo = "Lorem", UserImage = "~/Image/User/000004.png", Exp = 4, Logo = "~/Image/Logo/000004.png", WebURL = "Lorem", FacebookUrl = "Lorem", Address = "Lorem Categ", Email = "Lorem", PhoneNumber = "Lorem", City = "Lorem Category", Published = true, PostedOn = DateTime.Now });

            ////context.ParentCategories.AddOrUpdate(new Models.PageViewModels.ParentCategory { Id = "1", PCatName = "Lorem1", NumberOfPages = 1, UrlSeo = "Lore sit", Description = "Lore sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. " });
            ////context.ParentCategories.AddOrUpdate(new Models.PageViewModels.ParentCategory { Id = "2", PCatName = "Lorem2", NumberOfPages = 1, UrlSeo = "Lore sit", Description = "Lore sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. " });
            ////context.ParentCategories.AddOrUpdate(new Models.PageViewModels.ParentCategory { Id = "3", PCatName = "Lorem3", NumberOfPages = 1, UrlSeo = "Lore sit", Description = "Lore sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. " });
            ////context.ParentCategories.AddOrUpdate(new Models.PageViewModels.ParentCategory { Id = "4", PCatName = "Lorem4", NumberOfPages = 1, UrlSeo = "Lore sit", Description = "Lore sit amet, consectetur adipiscing elit. Vivamus nec dolor metus. " });

            ////context.ChildCategories.AddOrUpdate(new Models.PageViewModels.ChildCategory { PageId = "1", ParentCategoryId = "1", CCatName = "ChildCategory1", NumberOfPages = 1, UrlSeo = "1", Description = "cat1", });
            ////context.ChildCategories.AddOrUpdate(new Models.PageViewModels.ChildCategory { PageId = "2", ParentCategoryId = "2", CCatName = "ChildCategory1", NumberOfPages = 1, UrlSeo = "1", Description = "cat1", });
            ////context.ChildCategories.AddOrUpdate(new Models.PageViewModels.ChildCategory { PageId = "3", ParentCategoryId = "3", CCatName = "ChildCategory1", NumberOfPages = 1, UrlSeo = "1", Description = "cat1", });
            ////context.ChildCategories.AddOrUpdate(new Models.PageViewModels.ChildCategory { PageId = "4", ParentCategoryId = "4", CCatName = "ChildCategory1", NumberOfPages = 1, UrlSeo = "1", Description = "cat1", });


            ////context.PageImages.AddOrUpdate(new Models.PageViewModels.PageImage { Id = 1, ImageUrl = "~/Image/Images/000001.jpg", PageId = "1", ImageName = "ImageName1" });
            ////context.PageImages.AddOrUpdate(new Models.PageViewModels.PageImage { Id = 2, ImageUrl = "~/Image/Images/000002.jpg", PageId = "1", ImageName = "ImageName2" });
            ////context.PageImages.AddOrUpdate(new Models.PageViewModels.PageImage { Id = 3, ImageUrl = "~/Image/Images/000003.jpg", PageId = "2", ImageName = "ImageName3" });
            ////context.PageImages.AddOrUpdate(new Models.PageViewModels.PageImage { Id = 4, ImageUrl = "~/Image/Images/000004.jpg", PageId = "3", ImageName = "ImageName4" });
            ////context.PageImages.AddOrUpdate(new Models.PageViewModels.PageImage { Id = 5, ImageUrl = "~/Image/Images/000005.jpg", PageId = "4", ImageName = "ImageName5" });


        }
    }
}
