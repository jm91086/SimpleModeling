using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModelListener : AbstractModel    
    {

        void Start()
        {
            if ( GetSource() != null )
            {
                GetSource().AddListener(this);
            }
        }

        void Destroy()
        {
            if (GetSource() != null)
            {
                GetSource().RemoveListener(this);
            }
        }

        public virtual bool HandlesEvent(AbstractModelEvent mEvent)
        {
            return true;
        }

        public void ReceiveEvent(AbstractModelEvent mEvent)
        {
            if ( HandlesEvent(mEvent) )
            {
                ProcessEvent(mEvent);
            }
        }

        abstract protected AbstractModel GetSource();
        abstract protected void ProcessEvent(AbstractModelEvent evt);
    }
}
