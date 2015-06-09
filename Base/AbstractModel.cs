using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModel : MonoBehaviour
    {
        protected List<AbstractModelListener> listeners;

        protected List<AbstractModelListener> Listeners
        {
            get
            {
                if ( listeners == null )
                {
                    listeners = new List<AbstractModelListener>();
                }
                return listeners;
            }
        }

        public bool AddListener(AbstractModelListener listener)
        {
            if ( !Listeners.Contains(listener) )
            {
                Listeners.Add(listener);
                return true;
            }
            return false;
        }

        public bool RemoveListener(AbstractModelListener listener)
        {
            return Listeners.Remove(listener);
        }

        protected void NotifyListeners(AbstractModelEvent mEvent)
        {
            foreach ( AbstractModelListener listener in Listeners )
            {
                listener.ReceiveEvent(mEvent);
            }
        }
    }
}
