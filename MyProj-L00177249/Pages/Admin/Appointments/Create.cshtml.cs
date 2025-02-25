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
            PatientList = _unitOfWork.PatientRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.PPS.ToString()
            }) ;
            DoctorList = _unitOfWork.DoctorRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.ID.ToString()
            });
            Appointments = _unitOfWork.ApptRepo.GetAll();
        }

        public IActionResult OnPost(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ApptRepo.Add(appointment);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
