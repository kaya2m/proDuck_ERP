using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Machine.UpdateMachine
{
    public class UpdateMachineCommandHandler : IRequestHandler<UpdateMachineCommandRequest, UpdateMachineCommandResponse>
    {
        public Task<UpdateMachineCommandResponse> Handle(UpdateMachineCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
