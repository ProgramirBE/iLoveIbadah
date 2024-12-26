using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.DTOs.PermissionType;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using IbadahLover.Application.Features.PermissionTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermissionTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<PermissionTypeListDto>>> GetAll()
        {
            var permissionTypes = await _mediator.Send(new GetPermissionTypeListRequest());
            return permissionTypes;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PermissionTypeDto>> Get(int id) //Get or GetById??? check if issue! todo! error! debug! fix! test! review! verify! validate! confirm! check! inspect! examine! audit! revise! study! investigate! analyze! assess! evaluate! scrutinize! probe!
        {
            var permissionType = await _mediator.Send(new GetPermissionTypeDetailsRequest { Id = id });
            return Ok(permissionType);
        }

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
