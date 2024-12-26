using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Queries;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDhikrActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserDhikrActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserDhikrActivitiesController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserDhikrActivityListDto>>> GetAll()
        {
            var userDhikrActivities = await _mediator.Send(new GetUserDhikrActivityListRequest());
            return userDhikrActivities;
        }

        // GET api/<UserDhikrActivitiesController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDhikrActivityDto>> GetById(int id)
        {
            var userDhikrActivity = await _mediator.Send(new GetUserDhikrActivityDetailsRequest { Id = id });
            return Ok(userDhikrActivity);
        }

        // POST api/<UserDhikrActivitiesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserDhikrActivityDto userDhikrActivity)
        {
            var command = new CreateUserDhikrActivityCommand { UserDhikrActivityDto = userDhikrActivity };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UserDhikrActivitiesController>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateUserDhikrActivityDto userDhikrActivity)
        {
            var command = new UpdateUserDhikrActivityCommand { UserDhikrActivityDto = userDhikrActivity };
            await _mediator.Send(command);
            return NoContent();
        }

        // POST api/<UserDhikrActivitiesController>/import
        //[HttpPost]
        //public async Task<ActionResult> Import([FromBody] CreateUserDhikrActivityDto userDhikrActivity)
        //{
        //    // Check if a record for the same day exists
        //    var exists = await _mediator.Send(new CheckUserDhikrActivityExistsRequest
        //    {
        //        UserAccountId = userDhikrActivity.UserAccountId,
        //        DhikrTypeId = userDhikrActivity.DhikrTypeId,
        //        PerformedOn = userDhikrActivity.PerformedOn
        //    });

        //    if (exists)
        //    {
        //        // Get the existing activity
        //        var existingActivity = await _mediator.Send(new GetUserDhikrActivityByDateRequest
        //        {
        //            UserAccountId = userDhikrActivity.UserAccountId,
        //            DhikrTypeId = userDhikrActivity.DhikrTypeId,
        //            PerformedOn = userDhikrActivity.PerformedOn
        //        });

        //        // Update the existing record
        //        var updateDto = new UpdateUserDhikrActivityDto
        //        {
        //            Id = existingActivity.Id,
        //            UserAccountId = userDhikrActivity.UserAccountId,
        //            DhikrTypeId = userDhikrActivity.DhikrTypeId,
        //            PerformedOn = userDhikrActivity.PerformedOn,
        //            LastPerformedAt = userDhikrActivity.LastPerformedAt,
        //            TotalPerformed = userDhikrActivity.TotalPerformed
        //        };
        //        return await Update(updateDto);
        //    }
        //    else
        //    {
        //        // Create a new record
        //        return await Create(userDhikrActivity);
        //    }
        //}

        // PUT api/<UserDhikrActivitiesController>/import
        //[HttpPut("import")]
        //[HttpMethod] ??? how to or update or delete?
        //public async Task<ActionResult> Import([FromBody] UpdateUserDhikrActivityFromOfflineDto userDhikrActivityFromOffline)
        //{
        //    var command = new UpdateUserDhikrActivityFromOfflineCommand { UserDhikrActivityFromOfflineDto = userDhikrActivity };
        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        // DELETE api/<UserDhikrActivitiesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
