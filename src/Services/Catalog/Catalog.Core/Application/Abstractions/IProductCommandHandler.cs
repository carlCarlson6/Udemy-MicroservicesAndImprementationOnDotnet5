using System.Threading.Tasks;

namespace Catalog.Core.Application.Abstractions
{
    public interface IProductCreator
    {
        Task Create(CreateProductCommand command);
    }
}