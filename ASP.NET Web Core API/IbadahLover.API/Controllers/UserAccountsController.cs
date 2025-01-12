using IbadahLover.Application.Constants;
using IbadahLover.Application.Contracts.Identity;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Features.UserAccounts.Requests.Queries;
using IbadahLover.Application.Models.Identity;
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
    public class UserAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccountsController(IMediator mediator, IAuthService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _authenticationService = authenticationService;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        //[HttpGet("isLoggedIn")]
        //[AllowAnonymous]
        //public async Task<ActionResult<bool>> IsLoggedIn()
        //{
        //    var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
        //    if (userIdClaim == null)
        //    {
        //        return Unauthorized("User ID claim not found.");
        //    }
        //    return Ok(true);
        //}

        // GET: api/<UserAccountsController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserAccountListDto>>> GetAll()
        {
            var userAccounts = await _mediator.Send(new GetUserAccountListRequest());
            return userAccounts;
        }

        // GET api/<UserAccountsController>/5
        [HttpGet("getbyid")]
        [Authorize]
        public async Task<ActionResult<UserAccountDto>> GetById()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            int id = int.Parse(userIdClaim);
            var userAccount = await _mediator.Send(new GetUserAccountDetailsRequest { Id = id });
            return Ok(userAccount);
        }

        //--------------------->>>>> ACCOUNT CREATION HAPPENS IN REGISTER METHOD ABOVE <<<<---------------------

        //// POST api/<UserAccountsController>
        //[HttpPost]
        //[Authorize]
        //public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserAccountDto userAccount)
        //{
        //    var command = new CreateUserAccountCommand { UserAccountDto = userAccount };
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        // PUT api/<UserAccountsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateUserAccountDto userAccount)
        {
            var command = new UpdateUserAccountCommand { Id = id, UserAccountDto = userAccount };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<UserAccountsController>/updatepasswordhash/5
        [HttpPut("updatepasswordhash/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdatePasswordHash(int id, [FromBody] UpdateUserAccountPasswordHashDto userAccountPasswordHash)
        {
            var command = new UpdateUserAccountCommand { Id = id, UserAccountPasswordHashDto = userAccountPasswordHash };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<UserAccountsController>/updatetotalwarnings/5
        [HttpPut("updatetotalwarnings/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateTotalWarnings(int id, [FromBody] UpdateUserAccountTotalWarningsDto userAccountTotalWarnings)
        {
            var command = new UpdateUserAccountCommand { Id = id, UserAccountTotalWarningsDto = userAccountTotalWarnings };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<UserAccountsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
