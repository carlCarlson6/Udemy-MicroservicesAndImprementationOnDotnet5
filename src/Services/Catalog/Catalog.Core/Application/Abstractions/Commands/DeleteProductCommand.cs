namespace Catalog.Core.Application.Abstractions.Commands
{
    public class DeleteProductCommand
    {
        public string Id { get; }
        
        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}