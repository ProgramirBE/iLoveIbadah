using IbadahLover.Application.DTOs.UserAccountRoleTypeMapping;
using IbadahLover.Application.Features.UserAccountRoleTypeMappings.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountRoleTypeMappingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserAccountRoleTypeMappingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserAccountRoleTypeMappingsController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserAccountRoleTypeMappingListDto>>> GetAll()
        {
            var userAccountRoleTypeMappings = await _mediator.Send(new GetUserAccountRoleTypeMappingListRequest());
            return userAccountRoleTypeMappings;
        }

        // GET api/<UserAccountRoleTypeMappingsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserAccountRoleTypeMappingDto>> Get(int id)
        {
            var userAccountRoleTypeMapping = await _mediator.Send(new GetUserAccountRoleTypeMappingDetailsRequest { Id = id });
            return Ok(userAccountRoleTypeMapping);
        }

        // POST api/<UserAccountRoleTypeMappingsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserAccountRoleTypeMappingsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserAccountRoleTypeMappingsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
