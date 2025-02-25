using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using MyProj.Services;

namespace MyProj_L00177249.Pages.Admin.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Appointment> Appointment;

        public IndexModel(IUnitOfWork unitOfWork)

		{
			_unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Appointment = _unitOfWork.ApptRepo.GetAll(includeProperties: "Patient,Doctor");
        }
    }
}
