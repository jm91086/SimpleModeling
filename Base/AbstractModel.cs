using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    [Serializable]
    public abstract class AbstractModel
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
            Debug.Log(GetType() + ".AddListener");
            if ( !Listeners.Contains(listener) )
            {
                Debug.Log(GetType() + ".AddListener Adding Listener");
                Listeners.Add(listener);
                listener.ReceiveEvent(new ModelSetEvent(this));
                return true;
            }
            return false;
        }

        public bool RemoveListener(AbstractModelListener listener)
        {
            return Listeners.Remove(listener);
        }

        public void NotifyListeners(AbstractModelEvent mEvent)
        {
            foreach ( AbstractModelListener listener in Listeners )
            {
                listener.ReceiveEvent(mEvent);
            }

        }

        abstract public void CopyTo(AbstractModel model);
    }
}
