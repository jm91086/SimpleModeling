using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelMapAddEvent : AbstractModelMapEvent
    {
        public string Key
        {
            private set;
            get;
        }

        public AbstractModel Value
        {
            private set;
            get;
        }

        public ModelMapAddEvent(AbstractModelMap map, string key, AbstractModel value)
            :base(map)
        {
            Key = key;
            Value = value;
        }

        override public ModelMapEventType EventType()
        {
            return ModelMapEventType.Add;
        }
    }

}
