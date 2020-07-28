using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Data;
using ApiSample.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _unitOfWork.BillRepository.GetAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("getBillsByPersonId")]
        public async Task<IActionResult> GetBillsByPersonId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _unitOfWork.BillRepository.GetPersonBillsAsync(id);

            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(Bill bill, Guid personId)
        {
            if (bill == null || personId == Guid.Empty) return BadRequest();


            await _unitOfWork.BillRepository.AddAsync(bill);
            await _unitOfWork.BillRepository.AddPersonBill(bill.Id, personId);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

    }
}
