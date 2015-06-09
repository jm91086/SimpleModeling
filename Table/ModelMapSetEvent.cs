using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelMapSetEvent : AbstractModelMapEvent
    {
        public string Key
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

        public ModelMapSetEvent(AbstractModelMap map, string key, AbstractModel oldModel, AbstractModel newModel)
            :base(map)
        {
            Key = key;
            NewModel = newModel;
            OldModel = oldModel;
        }

        override public ModelMapEventType EventType()
        {
            return ModelMapEventType.Set;
        }
    }

}
