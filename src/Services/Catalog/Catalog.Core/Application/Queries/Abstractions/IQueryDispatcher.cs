using System.Threading.Tasks;

namespace Catalog.Core.Application.Queries.Abstractions
{
    public interface IQueryDispatcher
    {
        public Task<TR> Dispatch<T, TR>(T query) where T : IQuery<TR>;
    }
}