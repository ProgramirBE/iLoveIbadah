using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Commands;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Queries;
using IbadahLover.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSalahActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserSalahActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserSalahActivitiesController>
        [HttpGet]
        public async Task<ActionResult<List<UserSalahActivityListDto>>> GetAll()
        {
            var userSalahActivities = await _mediator.Send(new GetUserSalahActivityListRequest());
            return userSalahActivities;
        }

        // GET api/<UserSalahActivitiesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSalahActivityDto>> GetById(int id)
        {
            var userSalahActivity = await _mediator.Send(new GetUserSalahActivityDetailsRequest { Id = id });
            return Ok(userSalahActivity);
        }

        // POST api/<UserSalahActivitiesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateUserSalahActivityDto userSalahActivity)
        {
            var command = new UpdateUserSalahActivityCommand { UserSalahActivityDto = userSalahActivity };
            await _mediator.Send(command);
            return NoContent();
        }

        //// PUT api/<UserSalahActivitiesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserSalahActivityDto userSalahActivity)
        {
            var command = new CreateUserSalahActivityCommand { UserSalahActivityDto = userSalahActivity };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //// DELETE api/<UserSalahActivitiesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
