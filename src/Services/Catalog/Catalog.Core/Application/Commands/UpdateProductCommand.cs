using Catalog.Core.Application.Commands.Abstractions;

namespace Catalog.Core.Application.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public string Id { get; }
        public string Name { get; }
        public string Category { get; }
        public string Summary { get; }
        public string Description { get; }
        public string ImageFile { get; }
        public decimal Price { get; }
        
        public UpdateProductCommand(string id, string name, string category, string summary, string description, string imageFile, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Summary = summary;
            Description = description;
            ImageFile = imageFile;
            Price = price;
        }
    }
}