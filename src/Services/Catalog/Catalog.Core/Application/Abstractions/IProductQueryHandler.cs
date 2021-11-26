using System.Threading.Tasks;
using Catalog.Core.ValueObjects;

namespace Catalog.Core.Application.Abstractions
{
    public interface IProductRetriever
    {
        Task<Product?> Read(Identifier id);
    }
}