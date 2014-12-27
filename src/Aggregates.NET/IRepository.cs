﻿using Aggregates.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregates
{
    public interface IRepositoryBase : IDisposable
    {
        void Commit(Guid commitId, IDictionary<String, String> headers = null);
    }

    public interface IRepository<T> : IRepositoryBase where T : class, IEventSourceBase
    {
        T Get<TId>(TId id);
        T Get<TId>(TId id, Int32 version);
        T Get<TId>(String bucketId, TId id);
        T Get<TId>(String bucketId, TId id, Int32 version);

        
        IRepoNewChain<T> New<TId>(String bucketId, TId id);
        IRepoNewChain<T> New<TId>(TId id);

    }
    public interface IRepoNewChain<T>
    {
        T Apply<TEvent>(Action<TEvent> action);
    }

}
