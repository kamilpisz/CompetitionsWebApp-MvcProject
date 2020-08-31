using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaASPNET.Models;
using AplikacjaASPNET.Models.OrganisationItems;
using AplikacjaASPNET.Views.ViewModels.OrganisationVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaASPNET.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly ISQLOrganisationRepository _OrganisationRepository;
        private readonly AppDbContext _context;


        public OrganisationController(ISQLOrganisationRepository OrganisationRepository, AppDbContext context)
        {
            _OrganisationRepository = OrganisationRepository;
            _context = context;

        }
        
        
        public ViewResult Index()
        {
            return View();
        }

        [Route("")]
        [Route("Organisation")]
        public IActionResult OrganisationList(string searchString, string OrganisationCategory, string sorting)
        {
            ViewData["fnSortdir"] = sorting == "Name" ? "Name_desc" : "Name";
            ViewData["idSortdir"] = sorting == "Id" ? "Id_desc" : "Id";
            ViewData["catSortdir"] = sorting == "Category" ? "Category_desc" : "Category";

            var query = _context.OrganisationDB.AsQueryable();


            if (!string.IsNullOrEmpty(OrganisationCategory))
                query = query.Where(a => a.Category == OrganisationCategory);
            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(a => a.Name.Contains(searchString) || a.Address.Contains(searchString));

            if (!string.IsNullOrEmpty(sorting))
                switch (sorting)
                {
                    case "Id":
                        query = query.OrderBy(q => q.OrganisationId);
                        break;
                    case "Id_desc":
                        query = query.OrderByDescending(q => q.OrganisationId);
                        break;
                    case "Name":
                        query = query.OrderBy(q => q.Name).ThenBy(q => q.Address);
                        break;
                    case "Name_desc":
                        query = query.OrderByDescending(q => q.Name).ThenBy(q => q.Address);
                        break;
                    case "Category":
                        query = query.OrderBy(q => q.Category).ThenBy(q => q.Name);
                        break;
                    case "Category_desc":
                        query = query.OrderByDescending(q => q.Category).ThenBy(q => q.Name);
                        break;
                    default:
                        query = query.OrderBy(q => q.OrganisationId);
                        break;
                }

            


            IQueryable<string> CategoriesQuery = _OrganisationRepository.GetAllCategories();



            var OrganisationList = new OrganisationListVM()
            {
                Categories = new SelectList(CategoriesQuery.Distinct()),
                Organisations = query.ToList()
            };


            return View(OrganisationList);

        }

        public ActionResult OrganisationDetails(int? id)
        {



            Organisation Organisation = _OrganisationRepository.GetById(id ?? 1);


            return View(Organisation);

        }

        public ViewResult NotFound()
        {
            return View();
        }

        [HttpGet]
        
        public ViewResult OrganisationCreate()
        {

            return View();
        }
        [HttpPost]
        
        public IActionResult OrganisationCreate(Organisation nowyOrganisation)
        {
            if (ModelState.IsValid)
            {
                Organisation newemploye = _OrganisationRepository.Create(nowyOrganisation);
                return RedirectToAction("details", new { id = newemploye.OrganisationId });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _OrganisationRepository.Delete(id);
            return RedirectToAction("OrganisationList");

        }

        [HttpGet]
        public ViewResult OrganisationEdit(int id)
        {
            Organisation Organisation = _OrganisationRepository.GetById(id);
            OrganisationEditVM OrganisationEditViewModel = new OrganisationEditVM()
            {
                OrganisationId = Organisation.OrganisationId,
                Name = Organisation.Name,
                Category = Organisation.Category,
                Address = Organisation.Address,
                Email = Organisation.Email,
                PhoneNumber = Organisation.PhoneNumber,
                Description = Organisation.Description,
                
            };

            return View(OrganisationEditViewModel);
        }
        [HttpPost]
        public IActionResult OrganisationEdit(OrganisationEditVM model)
        {
            if (ModelState.IsValid)
            {
                Organisation Organisation = _OrganisationRepository.GetById(model.Id);

                Organisation.Name = model.Name;
                Organisation.Category = model.Category;
                Organisation.Address = model.Address;
                Organisation.Email = model.Email;
                Organisation.PhoneNumber = model.PhoneNumber;
                Organisation.Description = model.Description;
                _OrganisationRepository.Edit(Organisation);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }



    }
}
