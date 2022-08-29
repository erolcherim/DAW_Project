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
            var results = (await _unitOfWork.Companies.GetAll()).Select(a => new CompanyDTO(a)).ToList();
            return results;
        }

        //GET: api/Companies/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var result = await _unitOfWork.Companies.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound("Company with specified id doesn't exist");
            }

            return new CompanyDTO(result);
        }

        //PUT: api/Companies/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDTO company)
        {
            var companyInDb = await _unitOfWork.Companies.GetByIdAsync(id);

            if (companyInDb == null)
            {
                return NotFound("Company with specified id doesn't exist");
            }

            companyInDb.CompanyName = company.CompanyName;
            companyInDb.CEO = company.CEO;
            companyInDb.CompanyLogo = company.CompanyLogo;

            await _unitOfWork.Companies.Update(companyInDb);
            _unitOfWork.Save();

            return Ok();
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> PostCompany(CompanyDTO company)
        {
            var companyToAdd = new Company();
            companyToAdd.CompanyName = company.CompanyName;
            companyToAdd.CEO = company.CEO;
            companyToAdd.CompanyLogo = company.CompanyLogo;

            await _unitOfWork.Companies.Create(companyToAdd);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyInDb = await _unitOfWork.Companies.GetByIdAsync(id);

            if (companyInDb == null)
            {
                return NotFound("Company with specifieed id doesn't exist");
            }

            await _unitOfWork.Companies.Delete(companyInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }

}
