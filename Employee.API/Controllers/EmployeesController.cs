using AutoMapper;
using Employee.API.Dtos;
using Employee.Domain.Models;
using Employee.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee.API.Controllers
{
    
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        //GET api/employees
        [HttpGet("private-scoped")]
        [Authorize("read:employeees")]
        public ActionResult<IEnumerable<StaffReadDto>> GetAllStaff()
        {
         
            var x = _repo.GetAllStaff();

            return Ok(_mapper.Map<IEnumerable<StaffReadDto>>(x));
        }



        //GET api/employees/{id}
        [HttpGet("{id}", Name = "GetStaffById")]
        public ActionResult<StaffReadDto> GetStaffById(int id)
        {
            var x = _repo.GetStaffbyId(id);
            if (x != null)
            {
                return Ok(_mapper.Map<StaffReadDto>(x));
            }

            return NotFound();
        }




        //POST api/employe
        [HttpPost]
        public ActionResult<StaffReadDto> CreateMember(StaffCreateDto staffCreateDto)
        {
            var  x = _mapper.Map<Staff>(staffCreateDto);
            _repo.CreateMember(x);
            _repo.SaveChanges();


            var staffReadDto = _mapper.Map<StaffReadDto>(x);

            return CreatedAtRoute(nameof(GetStaffById), new  { Id = staffReadDto.Id }, staffReadDto);
        }




        //PUT api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, StaffUpdateDto staffUpdateDto)
        {
            var x = _repo.GetStaffbyId(id);
            if (x == null)
            {
                return NotFound();
            }

            _mapper.Map(staffUpdateDto, x);

            _repo.UpdateMember(x);
            _repo.SaveChanges();
            return NoContent();
        }



        //PATCH api/employees/{id}
        [HttpPatch("private-scoped/{id}")]
        [Authorize("update:employees")]
        public ActionResult PartialStaffUpdate(int id, JsonPatchDocument<StaffUpdateDto> patchDoc)
        {
            var x = _repo.GetStaffbyId(id);
            if (x == null)
            {
                return NotFound();
            }
            var StaffToPatch = _mapper.Map<StaffUpdateDto>(x);
            patchDoc.ApplyTo(StaffToPatch, ModelState);

            if (!TryValidateModel(StaffToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(StaffToPatch, x);

            _repo.UpdateMember(x);

            _repo.SaveChanges();

            return NoContent();
        }



        //DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var x = _repo.GetStaffbyId(id);
            if (x == null)
            {
                return NotFound();
            }
            _repo.DeleteMember(x);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}
