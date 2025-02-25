using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
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
                _unitOfWork.PatientRepo.Delete(patient);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
