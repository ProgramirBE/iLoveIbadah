using IbadahLover.Application.Constants;
using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries;
using IbadahLover.Application.Features.UserSalahOverviews.Requests.Queries;
using IbadahLover.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDhikrOverviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserDhikrOverviewsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<UserDhikrOverviewsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<UserDhikrOverviewListDto>>> GetAll()
        {
            var userDhikrOverviews = await _mediator.Send(new GetUserDhikrOverviewListRequest());
            return userDhikrOverviews;
        }

        // GET api/<UserDhikrOverviewsController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDhikrOverviewDto>> GetById(int id)
        {
            var userDhikrOverview = await _mediator.Send(new GetUserDhikrOverviewDetailsRequest { Id = id });
            return Ok(userDhikrOverview);
        }

        // GET api/<UserdhikrOverviewsController>/getbyuseraccount
        [HttpGet("getbyuseraccount")]
        [Authorize]
        public async Task<ActionResult<UserSalahOverviewDto>> GetByUserAccount()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            var userDhikrOverview = await _mediator.Send(new GetUserDhikrOverviewByUserAccountDetailsRequest { UserAccountId = int.Parse(userIdClaim) });
            return Ok(userDhikrOverview);
        }

        // POST api/<UserDhikrOverviewsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserDhikrOverviewsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserDhikrOverviewsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
