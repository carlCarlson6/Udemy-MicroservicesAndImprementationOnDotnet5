using System.Threading.Tasks;

namespace Catalog.Core.Application.Commands.Abstractions
{
    public interface ICommandDispatcher
    {
        public Task Dispatch<T>(T command) where T : ICommand;
    }
}