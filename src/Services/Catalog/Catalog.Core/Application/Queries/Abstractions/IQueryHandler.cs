using System.Threading.Tasks;

namespace Catalog.Core.Application.Queries.Abstractions
{
    public interface IQueryHandler<in T, TR> where T : IQuery<TR>
    {
        public Task<TR> Handle(T query);
    }
}