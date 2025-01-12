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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserSalahActivityListDto>>> GetAll()
        {
            var userSalahActivities = await _mediator.Send(new GetUserSalahActivityListRequest());
            return userSalahActivities;
        }

        // GET api/<UserSalahActivitiesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserSalahActivityDto>> GetById(int id)
        {
            var userSalahActivity = await _mediator.Send(new GetUserSalahActivityDetailsRequest { Id = id });
            return Ok(userSalahActivity);
        }

        [HttpGet("getallbytrackedon")]
        [Authorize]
        public async Task<ActionResult<UserDhikrActivityByPerformedOnDto>> GetAllByTrackedOn([FromQuery] DateTime trackedOn)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }

            var userDhikrActivity = await _mediator.Send(new GetUserSalahActivityListByTrackedOnRequest
            {
                UserAccountId = int.Parse(userIdClaim),
                TrackedOn = trackedOn
            });
            return Ok(userDhikrActivity);
        }

        [HttpPost("upsert")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Upsert([FromBody] UpdateUserSalahActivityDto userSalahActivity)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            userSalahActivity.UserAccountId = int.Parse(userIdClaim);
            var exists = await _mediator.Send(new CheckUserSalahActivityTrackedOnExistsRequest
            {
                UserAccountId = userSalahActivity.UserAccountId,
                SalahTypeId = userSalahActivity.SalahTypeId,
                TrackedOn = userSalahActivity.TrackedOn
            });

            if (exists)
            {
                return await Update(userSalahActivity);
            }
            else
            {
                var createDto = new CreateUserSalahActivityDto
                {
                    UserAccountId = userSalahActivity.UserAccountId.Value,
                    SalahTypeId = userSalahActivity.SalahTypeId,
                    TrackedOn = userSalahActivity.TrackedOn,
                    PunctualityPercentage = userSalahActivity.PunctualityPercentage
                };
                return await Create(createDto);
            }
        }

        // POST api/<UserSalahActivitiesController>/5
        [HttpPut("update")]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UpdateUserSalahActivityDto userSalahActivity)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            userSalahActivity.UserAccountId = int.Parse(userIdClaim);
            var command = new UpdateUserSalahActivityCommand { UserSalahActivityDto = userSalahActivity };
            await _mediator.Send(command);
            return NoContent();
        }

        //// PUT api/<UserSalahActivitiesController>
        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserSalahActivityDto userSalahActivity)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            userSalahActivity.UserAccountId = int.Parse(userIdClaim);
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
