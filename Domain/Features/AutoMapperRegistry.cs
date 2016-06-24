namespace Domain.Features
{
    using System;
    using System.Linq;
    using AutoMapper;
    using StructureMap;

    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<AutoMapperRegistry>();
                scan.AddAllTypesOf<Profile>();
            });

            For<MapperConfiguration>().Use("Build AutoMapper config", ctx =>
            {
                var profiles = ctx.GetAllInstances<Profile>();
                var config = new MapperConfiguration(cfg =>
                {
                    //AutoMapperConfig.Configure(cfg);

                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }
                });
                return config;
            }).Singleton();

            For<IMapper>().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));
        }
    }
}