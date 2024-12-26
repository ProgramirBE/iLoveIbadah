using IbadahLover.Application.DTOs.RoleType;
using IbadahLover.Application.Features.RoleTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<RoleTypeListDto>>> GetAll()
        {
            var roleTypes = await _mediator.Send(new GetRoleTypeListRequest());
            return roleTypes;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RoleTypeDto>> Get(int id)
        {
            var roleType = await _mediator.Send(new GetRoleTypeDetailsRequest { Id = id });
            return Ok(roleType);
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
