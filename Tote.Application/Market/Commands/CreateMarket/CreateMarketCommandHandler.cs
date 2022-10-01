using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tote.Application.Market.Common.Interfaces;

namespace Tote.Application.Market.Commands.CreateMarket
{
    internal class CreateMarketCommandHandler : IRequestHandler<CreateMarketCommand, Guid>
    {
        private readonly IMarketWriter _marketWriter;

        public CreateMarketCommandHandler(IMarketWriter marketWriter)
        {
            _marketWriter = marketWriter;
        }

        public async Task<Guid> Handle(CreateMarketCommand request, CancellationToken cancellationToken)
        {
            return await _marketWriter.WriteAsync(request.NewMarket, cancellationToken);
        }
    }
}
