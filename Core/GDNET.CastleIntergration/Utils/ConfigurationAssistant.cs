using System.IO;
using System.Linq;
using System.Reflection;
using GDNET.Base.DomainAbstraction;
using GDNET.Base.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace GDNET.CastleIntergration.Utils
{
    public static class ConfigurationAssistant
    {
        public static Configuration BuildConfiguration(string mappingAssembliesFile, string hibernateConfigurationFile, string applicationDirectory, params IInterceptor[] interceptors)
        {
            var mapper = BuildModelMapper(mappingAssembliesFile, applicationDirectory);
            var cfg = new Configuration();

            if (File.Exists(hibernateConfigurationFile))
            {
                cfg.Configure(hibernateConfigurationFile);
            }

            if (mapper != null)
            {
                cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            }

            foreach (var interceptor in interceptors)
            {
                cfg.SetInterceptor(interceptor);
            }

            return cfg;
        }

        private static ModelMapper BuildModelMapper(string mappingAssembliesFile, string applicationDirectory)
        {
            var mapper = new ModelMapper();

            if (File.Exists(mappingAssembliesFile))
            {
                foreach (var line in File.ReadAllLines(mappingAssembliesFile).Where(ValidatedLine))
                {
                    var assemblyFullPath = Path.Combine(applicationDirectory, line);
                    var asm = Assembly.LoadFile(assemblyFullPath);
                    var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(IEntityMapping), asm);
                    mapper.AddMappings(listeMappingTypes);
                }
            }

            return mapper;
        }

        private static bool ValidatedLine(string line)
        {
            return !(string.IsNullOrEmpty(line) || line.StartsWith("#"));
        }
    }
}
