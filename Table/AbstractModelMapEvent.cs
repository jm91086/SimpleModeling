using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelMapEvent : AbstractModelEvent
    {
        public AbstractModelMap Map
        {
            private set;
            get;
        }

        public AbstractModelMapEvent(AbstractModelMap map)
            : base(map, "map", map, map)
        {
            Map = map;
        }

        public abstract ModelMapEventType EventType();
    }

    public enum ModelMapEventType
    {
        Add,
        Clear,
        Remove,
        Set
    }
}
