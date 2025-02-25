using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Patients
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PatientRepo.Add(patient);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
