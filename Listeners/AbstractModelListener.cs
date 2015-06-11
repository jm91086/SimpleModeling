using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModelListener : AbstractModel
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

        public virtual bool HandlesEvent(AbstractModelEvent mEvent)
        {
            return true;
        }

        virtual public void ReceiveEvent(AbstractModelEvent mEvent)
        {
            Debug.Log(GetType() + ".ReceiveEvent");
            if ( HandlesEvent(mEvent) )
            {
                ProcessEvent(mEvent);
            }
        }

        virtual public AbstractModel GetSource()
        {
            return Source;
        }

        abstract protected void ProcessEvent(AbstractModelEvent evt);

        public override void CopyTo(AbstractModel model)
        {
            AbstractModelListener listener = model as AbstractModelListener;
            if (listener != null)
            {
                listener.source = this.Source;
                listener.NotifyListeners(new ModelSetEvent(listener));
            }
        }
    }
}
