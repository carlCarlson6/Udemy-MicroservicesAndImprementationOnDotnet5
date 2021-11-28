using System.Threading.Tasks;

namespace Catalog.Core.Application.Commands.Abstractions
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task Handle(T command);
    }
}