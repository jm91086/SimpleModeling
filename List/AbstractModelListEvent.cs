using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelListEvent : AbstractModelEvent
    {
        public AbstractModelList List
        {
            private set;
            get;
        }

        public AbstractModelListEvent(AbstractModelList list)
            :base(list, "list", list, list)
        {
            List = list;
        }

        public abstract ModelListEventType EventType();
    }

    public enum ModelListEventType
    {
        Add,
        Clear,
        Remove,
        Set
    }
}
