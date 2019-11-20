using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Linq;

namespace TestMusicAppServer.Api.DependencyResolvers
{
    public static class MediatRDependencyResolver
    {
        public static void AddMediatRForSolution(this IServiceCollection services, string projectPrefix)
        {
            var libraries = DependencyContext.Default.RuntimeLibraries
                .Where(l => l.Name.StartsWith(projectPrefix))
                .ToList();

            foreach (var library in libraries)
            {
                var assembly = AppDomain.CurrentDomain.Load(library.Name);
                services.AddMediatR(assembly);
            }
        }
    }
}
