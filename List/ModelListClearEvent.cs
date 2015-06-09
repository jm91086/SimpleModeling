using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelListClearEvent : AbstractModelListEvent
    {

        public ModelListClearEvent(AbstractModelList list)
            :base(list)
        {
        }

        override public ModelListEventType EventType()
        {
            return ModelListEventType.Clear;
        }
    }

}
