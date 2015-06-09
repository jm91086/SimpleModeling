using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelCollectionChildEvent : AbstractModelEvent
    {
        public AbstractModelCollection Collection
        {
            private set;
            get;
        }

        public AbstractModelEvent Event
        {
            private set;
            get;
        }

        public ModelCollectionChildEvent(AbstractModelCollection collection, AbstractModelEvent mEvent)
            :base(mEvent.Source, mEvent.Property, mEvent.OldValue, mEvent.NewValue)
        {
            Collection = collection;
            Event = mEvent;
        }
    }
}
