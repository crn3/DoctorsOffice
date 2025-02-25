using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Doctors
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Doctor Doctor { get; set; }
        //public void OnGet(int id)
        //{
        //    Doctor = _unitOfWork.DoctorRepo.Get(id);
        //}

        public IActionResult OnPost(Doctor doctor)
        {
            if(ModelState.IsValid) 
            {
                _unitOfWork.DoctorRepo.Update(doctor);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
