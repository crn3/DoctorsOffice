using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Appointment Appointment { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        public IEnumerable<SelectListItem> PatientList { get; set; }
        public void OnGet(string id)
        {
            Appointment = _unitOfWork.ApptRepo.Get(id);
        }

        public IActionResult OnPost(Appointment appointment)
        {
            if(ModelState.IsValid) 
            {
                _unitOfWork.ApptRepo.Delete(appointment);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
