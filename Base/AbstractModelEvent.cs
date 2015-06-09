using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelEvent
    {
        public AbstractModel Source
        {
            get;
            private set;
        }

        public string Property
        {
            get;
            private set;
        }

        public object OldValue
        {
            get;
            private set;
        }

        public object NewValue
        {
            get;
            private set;
        }

        public Type OldType
        {
            get;
            private set;
        }

        public Type NewType
        {
            get;
            private set;
        }

        public DateTime Timestamp
        {
            get;
            private set;
        }

        public AbstractModelEvent(AbstractModel source, string property, object oldVal, object newVal)
        {
            Source = source;
            OldType = null;
            NewType = null;

            if ( oldVal != null )
            {
                OldType = oldVal.GetType();
            }

            if (newVal != null)
            {
                NewType = newVal.GetType();
            }

            Property = property;
            OldValue = oldVal;
            NewValue = newVal;
            Timestamp = DateTime.Now;
        }
    }
}
