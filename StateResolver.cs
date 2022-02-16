using System.Linq.Expressions;
using System.Reflection;

namespace StatePattern
{
    public class StateResolver<T> : IState<T>
    {
        private readonly Dictionary<string, object> _propertyStates = new();

        public StateResolver<T> AddPropertyState(Expression<Func<T, object>> property, object value)
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

            _propertyStates.Add(name, value);

            return this;
        }

        public void ApplyStates(T entity)
        {
            foreach (var property in _propertyStates.Keys)
            {
                Type? type = typeof(T);

                PropertyInfo? propertyInfo = type.GetProperty(property);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entity, _propertyStates[property]);
                }
            }
        }
    }
}
