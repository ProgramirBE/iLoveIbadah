using IbadahLover.Application.DTOs.RoleTypePermissionTypeMapping;
using IbadahLover.Application.Features.RoleTypePermissionTypeMappings.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleTypePermissionTypeMappingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleTypePermissionTypeMappingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<RoleTypePermissionTypeMappingListDto>>> GetAll()
        {
            var roleTypePermissionTypeMappings = await _mediator.Send(new GetRoleTypePermissionTypeMappingListRequest());
            return roleTypePermissionTypeMappings;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RoleTypePermissionTypeMappingDto>> Get(int id)
        {
            var RoleTypePermissionTypeMapping = await _mediator.Send(new GetRoleTypePermissionTypeMappingDetailsRequest { Id = id });
            return Ok(RoleTypePermissionTypeMapping);
        }

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
