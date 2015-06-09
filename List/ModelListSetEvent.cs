using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelListSetEvent : AbstractModelListEvent
    {
        public int Index
        {
            private set;
            get;
        }

        public AbstractModel NewModel
        {
            private set;
            get;
        }

        public AbstractModel OldModel
        {
            private set;
            get;
        }

        public ModelListSetEvent(AbstractModelList list, int index, AbstractModel oldModel, AbstractModel newModel)
            :base(list)
        {
            Index = index;
            NewModel = newModel;
            OldModel = oldModel;
        }

        override public ModelListEventType EventType()
        {
            return ModelListEventType.Set;
        }
    }

}
