using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public interface IState<T>
    {
        public void ApplyStates(T entity);
    }
}
