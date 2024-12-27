using IbadahLover.Application.Constants;
using IbadahLover.Application.DTOs.UserDhikrActivity;
using IbadahLover.Application.DTOs.UserSalahActivity;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Commands;
using IbadahLover.Application.Features.UserDhikrActivities.Requests.Queries;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Commands;
using IbadahLover.Application.Features.UserSalahActivities.Requests.Queries;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSalahActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IHttpContextAccessor _httpContextAccessor;
        public UserSalahActivitiesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<UserSalahActivitiesController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserSalahActivityListDto>>> GetAll()
        {
            var userSalahActivities = await _mediator.Send(new GetUserSalahActivityListRequest());
            return userSalahActivities;
        }

        // GET api/<UserSalahActivitiesController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserSalahActivityDto>> GetById(int id)
        {
            var userSalahActivity = await _mediator.Send(new GetUserSalahActivityDetailsRequest { Id = id });
            return Ok(userSalahActivity);
        }

        // POST api/<UserSalahActivitiesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateUserSalahActivityDto userSalahActivity)
        {
            var command = new UpdateUserSalahActivityCommand { UserSalahActivityDto = userSalahActivity };
            await _mediator.Send(command);
            return NoContent();
        }

        //// PUT api/<UserSalahActivitiesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserSalahActivityDto userSalahActivity)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            userSalahActivity.UserAccountId = int.Parse(userIdClaim);

            var exists = await _mediator.Send(new CheckUserSalahActivityPerformedOnExistsRequest
            {
                UserAccountId = userSalahActivity.UserAccountId,
                SalahTypeId = userSalahActivity.SalahTypeId,
                TrackedOn = userSalahActivity.TrackedOn
            });

            if (exists)
            {
                return BadRequest("User Salah Activity already exists for the day.");
                //var createDto = new UpdateUserSalahActivityDto
                //{
                //    UserAccountId = userDhikrActivity.UserAccountId.Value,
                //    SalahTypeId = userDhikrActivity.DhikrTypeId
                //};
                //return await Update(userSalahActivity);
            }
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
