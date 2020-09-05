using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AplikacjaASPNET.Views.ViewModels.OrganisationVM;
using AplikacjaASPNET.Views.ViewModels.OrganisationVM;
using AutoMapper;
using Competitions.Domain.Organisation;
using Competitions.Infrastructure._Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaASPNET.Controllers
{
    [Route("/Organisation")]
    public class OrganisationController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public OrganisationController(AppDbContext context, IMapper mapper)
        {
            
            _context = context;
            _mapper = mapper;

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

            


            IQueryable<string> CategoriesQuery = _context.GetAllCategories();



            var OrganisationList = new OrganisationListVM()
            {
                Categories = new SelectList(CategoriesQuery.Distinct()),
                Organisations = query.ToList()
            };


            return View(OrganisationList);

        }

        public ActionResult OrganisationDetails(int? id)
        {



            OrganisationM Organisation = _context.GetById(id ?? 1);


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
        
        public IActionResult OrganisationCreate(OrganisationM nowyOrganisation)
        {
            if (ModelState.IsValid)
            {
                Organisation newemploye = _context.Create(nowyOrganisation);
                return RedirectToAction("details", new { id = newemploye.OrganisationId });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _context.Delete(id);
            return RedirectToAction("OrganisationList");

        }

        [HttpGet]
        public ViewResult OrganisationEdit(int id)
        {
            Organisation Organisation = _context.GetById(id);
            OrganisationEditVM OrganisationEditViewModel = new OrganisationEditVM()
            {
                
                
            };

            return View(OrganisationEditViewModel);
        }
        [HttpPost]
        public IActionResult OrganisationEdit(OrganisationEditVM model)
        {
            if (ModelState.IsValid)
            {
                OrganisationM Organisation = _context.GetById(model.Id);

                
                _context.Edit(Organisation);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }



    }
}
