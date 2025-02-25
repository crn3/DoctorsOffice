using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Patients
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Patient Patient { get; set; }
        public void OnGet(string id)
        {
            Patient = _unitOfWork.PatientRepo.Get(id);
        }

        public IActionResult OnPost(Patient patient)
        {
            if(ModelState.IsValid) 
            {
                _unitOfWork.PatientRepo.Update(patient);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
