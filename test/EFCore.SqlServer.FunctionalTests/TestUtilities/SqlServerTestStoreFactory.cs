// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class SqlServerTestStoreFactory : RelationalTestStoreFactory
    {
        private readonly bool? _multipleActiveResultSets;

        public static SqlServerTestStoreFactory Instance { get; } = new SqlServerTestStoreFactory();

        public SqlServerTestStoreFactory(bool? multipleActiveResultSets = null)
            => _multipleActiveResultSets = multipleActiveResultSets;

        public override TestStore Create(string storeName)
            => SqlServerTestStore.Create(storeName, multipleActiveResultSets: _multipleActiveResultSets);

        public override TestStore GetOrCreate(string storeName)
            => SqlServerTestStore.GetOrCreate(storeName, _multipleActiveResultSets);

        public override IServiceCollection AddProviderServices(IServiceCollection serviceCollection)
            => serviceCollection.AddEntityFrameworkSqlServer();
    }
}
