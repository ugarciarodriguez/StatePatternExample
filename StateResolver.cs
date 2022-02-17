using System.Linq.Expressions;
using System.Reflection;

namespace StatePattern
{
    public abstract class StateResolver<T>
    {
        private readonly Dictionary<string, object> _propertyStates = new();

        protected abstract T Entity { get; }

        protected StateResolver<T> AddPropertyState<U>(Expression<Func<T, object>> property, Expression<Func<U, bool>> value)
        {
            MemberExpression? expression;
            
            if (property.Body is UnaryExpression unaryExpression)
            {
                expression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                expression = property.Body as MemberExpression;
            }

            string? name = expression?.Member.Name;

            if (name == null) 
            {
                throw new InvalidOperationException();
            }
            
            _propertyStates.Add(name, value);

            return this;
        }

        protected virtual void ApplyStates<U>(U context)
        {
            foreach (var property in _propertyStates.Keys)
            {
                Type? type = typeof(T);

                PropertyInfo? propertyInfo = type.GetProperty(property);

                var value = ((Expression<Func<U, bool>>)_propertyStates[property]).Compile()(context);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(Entity, value);
                }
            }
        }
    }
}
