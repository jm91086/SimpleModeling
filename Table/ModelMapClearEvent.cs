using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelMapClearEvent : AbstractModelMapEvent
    {

        public ModelMapClearEvent(AbstractModelMap map)
            : base(map)
        {
        }

        override public ModelMapEventType EventType()
        {
            return ModelMapEventType.Clear;
        }
    }

}
