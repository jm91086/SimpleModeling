using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class PropertyChangeEvent : AbstractModelEvent
    {
        public PropertyChangeEvent(AbstractModel source, string property, object oldVal, object newVal)
            :base(source, property, oldVal, newVal)
        {

        }
    }
}
