using AutoMapper;
using IbadahLover.Application.DTOs.UserAccount;
using IbadahLover.Application.Features.UserAccounts.Handlers.Commands;
using IbadahLover.Application.Features.UserAccounts.Requests.Commands;
using IbadahLover.Application.Profiles;
using IbadahLover.Application.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveIbadah.Application.UnitTests.UserAccounts.Commands
{
    public class CreateUserAccountCommandHandlerTests
    {
        //private readonly IMapper _mapper;
        //private readonly Mock<IUnitOfWork> _mockUow;
        //private readonly CreateUserAccountDto _handler;

        //public CreateUserAccountCommandHandlerTests()
        //{
        //    _mockUow = MockUnitOfWork.GetUnitOfWork();

        //    var mapperConfig = new MapperConfiguration(c =>
        //    {
        //        c.AddProfile<MappingProfile>();
        //    });

        //    _mapper = mapperConfig.CreateMapper();
        //    _handler = new CreateUserAccountCommandHandler(_mockUow.Object, _mapper);

        //    _userAccountDto = new CreateUserAccountDto
        //    {
        //        //
        //    }
        //}

        //[Fact]
        //public async Task Valid_UserAccount_Added()
        //{
        //    var result = await _handler.Handle(new CreateUserAccountCommand() { UserAccountDto = _userAccountDto }, CancellationToken.None);
        //    var userAccounts = await _mockRepo.Object.GetAll();
        //    result.ShouldBeOfType<BaseCommandResponse>();
        //    userAccounts.Count.ShouldBe(4);
        //}

        //[Fact]
        //public async Task InValid_UserAccount_Added()
        //{
        //    // _userAccountDto.DefaultDays = -1;
        //    var result = await _handler.Handle(new CreateUserAccountCommand() { UserAccountDto = _userAccountDto }, CancellationToken.None);
        //    var userAccounts = await _mockRepo.Object.UserAccountRepository.GetAll();
        //    userAccounts.Count.ShouldBe(3);
        //    result.ShouldBeOfType<BaseCommandResponse>();
        //}
    }
}
