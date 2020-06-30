using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using AutoMapper;

namespace Adsology.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => !x.IsDynamic)
                .SelectMany(x => x.GetExportedTypes())
                .Where(t => GetMappingInterface(t)!=null)
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping")
                                 ?? GetMappingInterface(type).GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
        private static Type GetMappingInterface(Type subject)
        {
           return subject.GetInterfaces().FirstOrDefault(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>));
        }
    
    }
}