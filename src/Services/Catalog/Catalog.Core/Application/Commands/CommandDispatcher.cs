using System;
using System.Threading.Tasks;
using Catalog.Core.Application.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task Dispatch<T>(T command) where T : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();
            return handler.Handle(command);
        }
    }
}