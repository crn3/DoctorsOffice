using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Doctor> Doctors;

        public IndexModel(IUnitOfWork unitOfWork)

		{
			_unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Doctors = _unitOfWork.DoctorRepo.GetAll();
        }
    }
}
