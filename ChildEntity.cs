using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class ChildEntity : StateResolver<ChildEntity>
    {
        public ChildEntity()
        {

        }

        protected override ChildEntity Entity => this;

        public bool IsEntityReadOnly { get; set; }

    }
}
