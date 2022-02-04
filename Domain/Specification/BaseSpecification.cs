using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; set; } = new List<string>();
    }
}
