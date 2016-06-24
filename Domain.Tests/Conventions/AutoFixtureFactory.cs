﻿namespace Domain.Conventions
{
    using System;
    using System.Collections.Concurrent;
    using Ploeh.AutoFixture;

    public class AutoFixtureFactory
    {
        private static readonly Lazy<AutoFixtureFactory> factory = new Lazy<AutoFixtureFactory>(() => new AutoFixtureFactory());

        private readonly ConcurrentDictionary<Type, IFixture> autoFixtureCache;

        private AutoFixtureFactory()
        {
            autoFixtureCache = new ConcurrentDictionary<Type, IFixture>();
        }

        public static AutoFixtureFactory Instance
        {
            get { return factory.Value; }
        }

        public IFixture BuildWith(ICustomization autoFixtureCustomization)
        {
            return autoFixtureCache.GetOrAdd(autoFixtureCustomization.GetType(), type => new Fixture().Customize(autoFixtureCustomization));
        }
    }
}