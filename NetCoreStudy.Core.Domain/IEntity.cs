﻿namespace NetCoreStudy.Core.Domain
{
    public interface IEntity
    {
        object[] GetKeys();
    }

    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
