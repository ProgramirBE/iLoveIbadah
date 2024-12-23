using IbadahLover.Application.Contracts.Identity;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Features.UserAccounts.Requests.Queries;
using IbadahLover.Application.Models.Identity;
using IbadahLover.Application.Responses;
using MediatR;
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
        public UserAccountsController(IMediator mediator, IAuthService authenticationService)
        {
            _mediator = mediator;
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        // GET: api/<UserAccountsController>
        [HttpGet]
        public async Task<ActionResult<List<UserAccountListDto>>> GetAll()
        {
            var userAccounts = await _mediator.Send(new GetUserAccountListRequest());
            return userAccounts;
        }

        // GET api/<UserAccountsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccountDto>> GetById(int id)
        {
            var userAccount = await _mediator.Send(new GetUserAccountDetailsRequest { Id = id });
            return Ok(userAccount);
        }

        // POST api/<UserAccountsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateUserAccountDto userAccount)
        {
            var command = new CreateUserAccountCommand { UserAccountDto = userAccount };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<UserAccountsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateUserAccountDto userAccount)
        {
            var command = new UpdateUserAccountCommand { Id = id, UserAccountDto = userAccount };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<UserAccountsController>/updatepasswordhash/5
        [HttpPut("updatepasswordhash/{id}")]
        public async Task<ActionResult> UpdatePasswordHash(int id, [FromBody] UpdateUserAccountPasswordHashDto userAccountPasswordHash)
        {
            var command = new UpdateUserAccountCommand { Id = id, UserAccountPasswordHashDto = userAccountPasswordHash };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<UserAccountsController>/updatetotalwarnings/5
        [HttpPut("updatetotalwarnings/{id}")]
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
