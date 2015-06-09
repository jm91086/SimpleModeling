using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelListAddEvent : AbstractModelListEvent
    {
        public int Index
        {
            private set;
            get;
        }

        public AbstractModel Value
        {
            private set;
            get;
        }

        public ModelListAddEvent(AbstractModelList list, int index, AbstractModel value)
            :base(list)
        {
            Index = index;
            Value = value;
        }

        override public ModelListEventType EventType()
        {
           return ModelListEventType.Add;
        }
    }

}
