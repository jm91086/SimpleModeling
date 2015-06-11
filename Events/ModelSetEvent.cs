using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public class ModelSetEvent : AbstractModelEvent
    {
        public ModelSetEvent(AbstractModel model)
            :base(model, "model", model, model)
        {
        }
    }

}
