using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Appointments
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Appointment> Appointments;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Appointment Appointment { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> PatientList { get; set; }
        public void OnGet()
        {
            DoctorList = _unitOfWork.DoctorRepo.GetAll().Select(d => new SelectListItem
            {
                Text = d.FirstName + " " + d.LastName,
                Value = d.ID.ToString()
            });

            PatientList = _unitOfWork.PatientRepo.GetAll().Select(p => new SelectListItem
            {
                Text = p.FirstName + " " + p.LastName,
                Value = p.PPS
            });

            Appointments = _unitOfWork.ApptRepo.GetAll();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Debugging output
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                // Repopulate the dropdowns
                DoctorList = _unitOfWork.DoctorRepo.GetAll().Select(d => new SelectListItem
                {
                    Text = d.FirstName + " " + d.LastName,
                    Value = d.ID.ToString()
                });

                PatientList = _unitOfWork.PatientRepo.GetAll().Select(p => new SelectListItem
                {
                    Text = p.FirstName + " " + p.LastName,
                    Value = p.PPS
                });

                return Page();
            }

            _unitOfWork.ApptRepo.Add(Appointment);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }


    }
}
