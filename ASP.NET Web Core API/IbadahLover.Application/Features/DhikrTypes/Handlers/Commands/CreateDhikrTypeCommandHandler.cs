using AutoMapper;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.DhikrType.Validators;
using IbadahLover.Application.Features.DhikrTypes.Requests.Commands;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Handlers.Commands
{
    public class CreateDhikrTypeCommandHandler : IRequestHandler<CreateDhikrTypeCommand, BaseCommandResponse>
    {
        private readonly IDhikrTypeRepository _dhikrTypeRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public CreateDhikrTypeCommandHandler(IDhikrTypeRepository dhikrTypeRepository, IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _dhikrTypeRepository = dhikrTypeRepository;
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDhikrTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateDhikrTypeDtoValidator(_dhikrTypeRepository, _userAccountRepository);
            var validationResult = await validator.ValidateAsync(request.DhikrTypeDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var dhikrType = _mapper.Map<DhikrType>(request.DhikrTypeDto);
            dhikrType = await _dhikrTypeRepository.Create(dhikrType);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = dhikrType.Id;

            return response;
        }
    }
}
