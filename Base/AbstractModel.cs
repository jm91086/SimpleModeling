using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    [Serializable]
    public abstract class AbstractModel : IModel
    {
        private List<IModelListener> listeners;

        protected List<IModelListener> Listeners
        {
            get
            {
                if ( listeners == null )
                {
                    listeners = new List<IModelListener>();
                }
                return listeners;
            }
        }

        public bool AddListener(IModelListener listener)
        {
            Debug.Log(GetType() + ".AddListener");
            if ( !Listeners.Contains(listener) )
            {
                Debug.Log(GetType() + ".AddListener Adding Listener");
                Listeners.Add(listener);
                return true;
            }
            return false;
        }

        public bool RemoveListener(IModelListener listener)
        {
            return Listeners.Remove(listener);
        }

        public void NotifyListeners(IModelEvent mEvent)
        {
            foreach (IModelListener listener in Listeners)
            {
                listener.ReceiveEvent(mEvent);
            }

        }
    }
}
