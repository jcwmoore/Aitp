using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aitp.Example
{
    public interface ICriteria<TEntity> : IEnumerable<Criterion> where TEntity : class
    {
        void Add(Criterion criterion);
    }
}
