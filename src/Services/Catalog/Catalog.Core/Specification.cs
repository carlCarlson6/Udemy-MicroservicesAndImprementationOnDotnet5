using System;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Core
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public Specification<T> And(Specification<T> specification) => 
            new AndSpecification<T>(this, specification);
        
        // TODO NOT specifications ...
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
 
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }
 
        public override Expression<Func<T , bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
 
            var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
 
            return Expression.Lambda<Func<T , bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
    
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
 
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }
 
        public override Expression<Func<T , bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
 
            var andExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
 
            return Expression.Lambda<Func<T , bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }

    public class ProductByNameSpecification : Specification<Product>
    {
        private readonly string _productName;

        public ProductByNameSpecification(string productName) => _productName = productName;

        public override Expression<Func<Product, bool>> ToExpression() => 
            product => _productName.Equals(product.Name);
    }
    
    public class ProductByCategorySpecification: Specification<Product>
    {
        private readonly string _productCategory;

        public ProductByCategorySpecification(string productCategory) => _productCategory = productCategory;

        public override Expression<Func<Product, bool>> ToExpression() =>
            product => _productCategory.Equals(product.Category);
    }
}