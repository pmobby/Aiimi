using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.DTO;
using Web.Core.Interfaces;
using Web.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonController(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonDTO>> Index()
        {
            var people = await _service.GetEverybody();
            var peopleDto = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(people);           

            return Ok(peopleDto);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<string>>> Search()
        {
            string searchTerm = HttpContext.Request.Query["term"].ToString();


            if (string.IsNullOrEmpty(searchTerm))
            {
                return BadRequest();
            }
            string search = searchTerm.ToLower();

            var people = await _service.GetPeopleBySearch(search);
            var peopleDto = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(people);

            var fullnames = peopleDto.Select(p => p.FullName).ToList();

            return Ok(fullnames);
        }

        [HttpGet("getperson/name")]
        public async Task<ActionResult<PersonDTO>> GetPerson(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                return BadRequest();
            }

            var person = await _service.GetPerson(fullname);
            var personDto = _mapper.Map<Person, PersonDTO>(person);
            return Ok(personDto);
        }

        [HttpPost]
        public ActionResult Add([FromBody] PersonDTO personDTO)
        {
            //personDTO parameter is a json object from the front-end
            var newPersonDto = new PersonDTO
            {
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                JobTitle = personDTO.JobTitle,
                Phone = personDTO.Phone,
                Email = personDTO.Email
            };
            var person = _mapper.Map<PersonDTO, Person>(newPersonDto);
            _service.AddUser(person);
            return Ok();
        }
    }
}
