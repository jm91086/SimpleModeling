using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public interface IModelListener
    {
        bool HandlesEvent(IModelEvent mEvent);
        void ReceiveEvent(IModelEvent mEvent);
        void ProcessEvent(IModelEvent evt);
    }
}
