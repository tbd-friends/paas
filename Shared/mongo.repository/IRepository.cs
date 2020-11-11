using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace mongo.repository
{
    public interface IRepository
    {
        Task Add<T>(T entity, string collectionName);
        Task<IEnumerable<TDocument>> Query<TDocument>(string collectionName, Expression<Func<TDocument, bool>> query);
    }
}