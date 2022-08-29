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
    public class BranchesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDTO>>> GetCompanies()
        {

            if (_unitOfWork.Branches == null)
            {
                return NotFound();
            }
            var results = (await _unitOfWork.Branches.GetAll()).Select(a => new BranchDTO(a)).ToList();
            return results;
        }

        //GET: api/Branches/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDTO>> GetCompany(int id)
        {
            var result = await _unitOfWork.Branches.GetById(id);

            if (result == null)
            {
                return NotFound("Branch with specified id doesn't exist");
            }

            return new BranchDTO(result);
        }

        //PUT: api/Branches/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, BranchDTO branch)
        {
            var branchInDb = await _unitOfWork.Branches.GetById(id);

            if (branchInDb == null)
            {
                return NotFound("company with specified id doesn't exist");
            }

            branchInDb.BranchName = branch.BranchName;
            branchInDb.BranchManager = branch.BranchManager;
            branchInDb.NumberOfEmployees = branch.NumberOfEmployees;
            branchInDb.Location = branch.Location;
            branchInDb.CompanyId = branch.CompanyId;

            await _unitOfWork.Branches.Update(branchInDb);
            _unitOfWork.Save();

            return Ok();
        }

        // POST: api/Branches
        [HttpPost]
        public async Task<ActionResult<BranchDTO>> PostCompany(BranchDTO branch)
        {
            var branchToAdd = new Branch();
            branchToAdd.BranchName = branch.BranchName;
            branchToAdd.BranchManager = branch.BranchManager;
            branchToAdd.NumberOfEmployees = branch.NumberOfEmployees;
            branchToAdd.Location = branch.Location;
            branchToAdd.CompanyId = branch.CompanyId;

            await _unitOfWork.Branches.Create(branchToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("get-join-by-id")]
        public async Task<IActionResult> GetBranchesByCompany(int id)
        {
            var result = await _unitOfWork.Branches.GetBranchesByCompanyId(id);

            if(result == null)
            {
                return NotFound($"There are no branches belonging to Company with id {id}");
            }
            return Ok(result);
        }


        // Delete: api/Branches/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branchInDb = await _unitOfWork.Branches.GetById(id);

            if (branchInDb == null)
            {
                return NotFound("Branch with specifieed id doesn't exist");
            }

            await _unitOfWork.Branches.Delete(branchInDb);
            _unitOfWork.Save();

            return Ok();
        }
    }

}
