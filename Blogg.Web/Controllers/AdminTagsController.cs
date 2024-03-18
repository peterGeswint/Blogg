using Blogg.Web.Data;
using Blogg.Web.Models.Domian;
using Blogg.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blogg.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggDbContext bloggDbContext;

        public AdminTagsController(BloggDbContext bloggDbContext)
        {
            this.bloggDbContext = bloggDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Mapping the add tag request to AddTag domain model.
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            bloggDbContext.Tags.Add(tag);
            bloggDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            //Use dbContext to read Tags

            var tags = bloggDbContext.Tags.ToList();

            return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //First Method
            // bloggDbContext.Tags.Find(id);
            //Second Method
            var tag = bloggDbContext.Tags.FirstOrDefault(x => x.Id == id);
            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagRequest);
            }
            return View();
        }
    }
}
