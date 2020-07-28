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
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _unitOfWork.PersonRepository.GetByIdAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.PersonRepository.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Person person)
        {
            if (person == null) return BadRequest();

            await _unitOfWork.PersonRepository.AddAsync(person);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Person person)
        {
            if (person == null) return BadRequest();

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.CommitAsync();

            return Ok();
        }


        [HttpPost("remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var result = await _unitOfWork.PersonRepository.GetByIdAsync(id);
            if (result == null) return NotFound();

            _unitOfWork.PersonRepository.Remove(result);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
