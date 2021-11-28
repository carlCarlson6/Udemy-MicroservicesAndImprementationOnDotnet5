using Catalog.Core.Application.Commands.Abstractions;

namespace Catalog.Core.Application.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public string Id { get; }
        
        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}