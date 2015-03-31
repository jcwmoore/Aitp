using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aitp.Example
{
    public class Criterion : IFilteredCriterion, IBlankCriterion
    {
        public Criteria Restriction { get; set; }
        public Operations Op { get; set; }
        public object Value { get; set; }

		private Criterion()
		{
		}

		public static IBlankCriterion Create()
		{
			return new Criterion();
		}
    }
	
	public interface IBlankCriterion { }
	public interface IFilteredCriterion { }

	public static class CiterionFluent
	{
		public static Criterion Where(this IBlankCriterion c, Criteria criteria)
		{
			var crit = c as Criterion;
			if (crit != null)
			{
				crit.Restriction = criteria;
				return crit;
			}
			return null;
		}

		public static Criterion IsEqualTo(this IFilteredCriterion c, object v)
		{
			var crit = c as Criterion;
			if (crit != null)
			{
				crit.Op = Operations.Equals;
				crit.Value = v;
				return crit;
			}
			return null;
		}

		public static Criterion IsNotEqualTo(this IFilteredCriterion c, object v)
		{
			var crit = c as Criterion;
			if (crit != null)
			{
				crit.Op = Operations.NotEqual;
				crit.Value = v;
				return crit;
			}
			return null;
		}
	}
}
