using Cortex.Mediator.Commands;
using Demo.Application.Contracts;
using Demo.Domain.Entities;
using Demo.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Features.Products.Commands
{
    public class ProductAddCommandHandler(IApplicationUnitOfWork applicationUnitOfWork,
        IMapper mapper) : 
        ICommandHandler<ProductAddCommannd, Product>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork = applicationUnitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Product> Handle(ProductAddCommannd command, 
            CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);
            product.Id = IdentityGenerator.NewSequentialGuid();

            await _applicationUnitOfWork.ProductRepository.AddAsync(product, cancellationToken);
            await _applicationUnitOfWork.SaveAsync(cancellationToken);

            return product;
        }
    }
}
