using System.Threading.Tasks;
using Catalog.Core.Application.Abstractions.Commands;

namespace Catalog.Core.Application.Abstractions
{
    public interface IProductCommandHandler
    {
        Task Handle(CreateProductCommand command);
        Task Handle(UpdateProductCommand command);
        Task Handle(DeleteProductCommand command);
    }
}