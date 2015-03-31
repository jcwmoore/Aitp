using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aitp.Example
{
    internal class GenericCriteria<TEntity> : ICriteria<TEntity> where TEntity : class
    {
        private ICollection<Criterion> _criteria = new LinkedList<Criterion>();

        public void Add(Criterion criterion)
        {
            // TODO: add type validation to the criterion's value object
            _criteria.Add(criterion);
        }

        public IEnumerator<Criterion> GetEnumerator()
        {
            return _criteria.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _criteria.GetEnumerator();
        }
    }
}
