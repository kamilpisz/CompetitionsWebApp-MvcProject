using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AplikacjaASPNET.Models;
using AplikacjaASPNET.Views.ViewModels;
using System.Data.SqlTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplikacjaASPNET.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IParticipantRepository _ParticipantRepository;
        private readonly AppDbContext _context;


        public ParticipantController(IParticipantRepository ParticipantRepository, AppDbContext context)
        {
            _ParticipantRepository = ParticipantRepository;
            _context = context;

        }
        
        [Route("Participant")]
        [Route("Participant/Index")]
        public ViewResult Index()
        {
            return View();
        }
        public IActionResult ParticipantList(string searchString, string ParticipantClassCodes, string sorting)
        {
            ViewData["fnSortdir"] = sorting == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewData["idSortdir"] = sorting == "Id" ? "Id_desc" : "Id";
            ViewData["ccodeSortdir"] = sorting == "ClassCode" ? "ClassCode_desc" : "ClassCode";

            var query = _context.ParticipantDB.AsQueryable();
            

            if (!string.IsNullOrEmpty(ParticipantClassCodes))
                query = query.Where(a => a.ClassCode == ParticipantClassCodes);
            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(a => a.FirstName.Contains(searchString) || a.Email.Contains(searchString));

            if (!string.IsNullOrEmpty(sorting))
                switch (sorting)
                {
                    case "Id":
                        query = query.OrderBy(q => q.Id);
                        break;
                    case "Id_desc":
                        query = query.OrderByDescending(q => q.Id);
                        break;
                    case "FirstName":
                        query = query.OrderBy(q => q.FirstName).ThenBy(q => q.LastName);
                        break;
                    case "FirstName_desc":
                        query = query.OrderByDescending(q => q.FirstName).ThenBy(q => q.LastName);
                        break;
                    case "ClassCode":
                        query = query.OrderBy(q => q.ClassCode).ThenBy(q => q.FirstName);
                        break;
                    case "ClassCode_desc":
                        query = query.OrderByDescending(q => q.ClassCode).ThenBy(q => q.FirstName);
                        break;
                    default:
                        query = query.OrderBy(q => q.Id);
                        break;
                }

            //


            IQueryable<string> classCodesQuery = _ParticipantRepository.GetAllClasses();
            
            

            var ParticipantClassCodeVM = new ParticipantClassCodeViewModel()
            {
                classCodes = new SelectList(classCodesQuery.Distinct()),
                Participants = query.ToList()
            };


            return View(ParticipantClassCodeVM);

        }

        public ActionResult Details(int? id)
        {



            Participant Participant = _ParticipantRepository.GetById(id ?? 1);
               
            
            return View(Participant);

        }

        public ViewResult NotFound()
        {
            return View();
        }

        [HttpGet]
        [Route("Participant/Create")]
        public ViewResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [Route("Participant/Create")]
        public IActionResult Create(Participant nowyParticipant)
        {
            if (ModelState.IsValid)
            {
                Participant newemploye = _ParticipantRepository.Create(nowyParticipant);
                return RedirectToAction("details", new { id = newemploye.Id });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _ParticipantRepository.Delete(id);
            return RedirectToAction("ParticipantList");

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Participant Participant = _ParticipantRepository.GetById(id);
            ParticipantEditViewModel ParticipantEditViewModel = new ParticipantEditViewModel()
            {
                Id = Participant.Id,
                FirstName = Participant.FirstName,
                LastName = Participant.LastName,
                ClassCode = Participant.ClassCode,
                Email = Participant.Email,
            };

            return View(ParticipantEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ParticipantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Participant Participant = _ParticipantRepository.GetById(model.Id);

                Participant.FirstName = model.FirstName;
                Participant.LastName = model.LastName;
                Participant.ClassCode = model.ClassCode;
                Participant.Email = model.Email;
                _ParticipantRepository.Edit(Participant);
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }

        
        
    }
}


