using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModelListener : AbstractModel, IModelListener
    {
        public static readonly string PRP_SOURCE = "Source";
        protected AbstractModel source;

        public AbstractModel Source
        {
            get
            {
                return source;
            }
            set
            {
                AbstractModel oldSource = source;
                source = value;
                NotifyListeners(new PropertyChangeEvent(this, PRP_SOURCE, oldSource, value));
            }
        }

        void Start()
        {
            Debug.Log(GetType() + ".Start");
            if ( GetSource() != null )
            {
                bool result = GetSource().AddListener(this);
                Debug.Log(GetType() + ".Start Added Listener: " + result);
            }
        }

        void Destroy()
        {
            Debug.Log(GetType() + ".Destroy");
            if (GetSource() != null)
            {
                GetSource().RemoveListener(this);
            }
        }

        public virtual bool HandlesEvent(IModelEvent mEvent)
        {
            return true;
        }

        virtual public void ReceiveEvent(IModelEvent mEvent)
        {
            Debug.Log(GetType() + ".ReceiveEvent");
            if ( HandlesEvent(mEvent) )
            {
                ProcessEvent(mEvent);
            }
        }

        virtual public IModel GetSource()
        {
            return Source;
        }

        abstract public void ProcessEvent(IModelEvent evt);

    }
}
