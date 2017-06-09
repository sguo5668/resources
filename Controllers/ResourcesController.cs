using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;
using ContosoUniversity.Models.SearchModel;

namespace ContosoUniversity.Controllers
{
    public class ResourcesController : Controller
    {

        private readonly SchoolContext _context;
		private IRepository<Culture> _repoCulture;
		private IRepository<Resource> _repoResource;
        public ResourcesController(SchoolContext context, IRepository<Culture> repoCulture, IRepository<Resource> repoResource)
        {
            _context = context;
            _repoCulture = repoCulture;
            _repoResource = repoResource;
        }




        public IActionResult Index(ResourceSearchModel searchModel)
        {


            //var schoolContext = _context.Resources.Include(d => d.Culture);
            //return View(schoolContext);


            var business = new ResourceBusinessLogic(_context, _repoCulture, _repoResource);
            var model = business.GetResources(searchModel);
            return View(model);


        }



		public IActionResult Edit(long id)
		{

			if (id == null)
			{
				return NotFound();
			}

			EditResourcesViewModel model = new EditResourcesViewModel();
			model.Cultures = _repoCulture.GetAll().Select(a => new SelectListItem
			{
				Text = $"{a.Name}",
				Value = a.Id.ToString()
			}).ToList();
			 Resource resource = _repoResource.Get(id);
			if (resource != null)
			{
				model.Key = resource.Key;
				model.Value = resource.Value;
                model.ResourceType = resource.ResourceType;

                model.CultureId = resource.CultureID;
			}
			return View(model);
		}


		[HttpPost]
		public IActionResult Edit(long id, EditResourcesViewModel model)
		{
			Resource resource = _repoResource.Get(id);
			if (resource != null)
			{
				resource.Key = model.Key;
				resource.Value = model.Value;
                resource.ResourceType = model.ResourceType;
                resource.CultureID = model.CultureId;

				resource.ModifiedDate = DateTime.UtcNow;
				_repoResource.Update(resource);
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Create()
		{
			EditResourcesViewModel model = new EditResourcesViewModel();
			model.Cultures = _repoCulture.GetAll().Select(a => new SelectListItem
			{
				Text = $"{a.Name}",
				Value = a.Id.ToString()
			}).ToList();
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(  EditResourcesViewModel model)
		{

			if (ModelState.IsValid)
			{

				//try
				//{
					Resource resource = new Resource
					{
						CultureID = model.CultureId,
						Key = model.Key,
						Value = model.Value,
                        ResourceType = model.ResourceType,
                        AddedDate = DateTime.UtcNow,
						ModifiedDate = DateTime.UtcNow
					};
					_repoResource.Insert(resource);

					//TempData["UserMessage"] = new { CssClassName = "alert-sucess", Title = "Success!", Message = "Operation Done." };

					//return RedirectToAction("Index");
					

				//}
				//catch (Exception e)
				//{
				//	//TempData["UserMessage"] = new { CssClassName = "alert-error", Title = "Error!", Message = "Operation Failed." };
				//	return RedirectToAction("Error");
				//}

			 }

			return View(model);
		}


	}
}