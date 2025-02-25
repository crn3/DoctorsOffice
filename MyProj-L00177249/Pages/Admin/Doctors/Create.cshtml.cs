using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Doctor> Doctors;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Doctor Doctor { get; set; }
        public void OnGet()
        {
            Doctors = _unitOfWork.DoctorRepo.GetAll();
        }

        public IActionResult OnPost(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DoctorRepo.Add(doctor);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
