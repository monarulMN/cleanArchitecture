using Cortex.Mediator.Commands;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Features.Products.Commands
{
    public class ProductAddCommannd : ICommand<Product>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
