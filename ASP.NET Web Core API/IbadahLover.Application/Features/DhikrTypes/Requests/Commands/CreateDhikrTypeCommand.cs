using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.DhikrTypes.Requests.Commands
{
    public class CreateDhikrTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDhikrTypeDto DhikrTypeDto { get; set; }
    }
}
