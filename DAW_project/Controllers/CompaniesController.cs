using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAW_Project.DAL;
using DAW_Project.DAL.Models;
using DAW_Project.Repositories.UnitOfWork;
using DAW_Project.DAL.DTO;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {

          if (_unitOfWork.Companies == null)
          {
              return NotFound();
          }
            var companies = (await _unitOfWork.Companies.GetAll()).Select(a => new CompanyDTO(a)).ToList();
            return companies;
        }
    }

}
