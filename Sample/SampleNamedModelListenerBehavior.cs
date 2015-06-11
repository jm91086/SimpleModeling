using jwm.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace jwm.Model
{
    [RequireComponent(typeof(Text))]
    public class SampleNamedModelListenerBehavior : AbstractModelListenerBehavior<SampleNamedModel>
    {
        protected MyListener listener;
        
        protected override AbstractModelListener GetModelListener()
        {
            Debug.Log(GetType() + ".GetModelListener");
            if ( listener == null )
            {
                listener = new MyListener(this);
            }
            return listener;
        }

        protected class MyListener : AbstractModelListener
        {
            protected SampleNamedModelListenerBehavior behavior;

            public MyListener(SampleNamedModelListenerBehavior behavior)
            {
                this.behavior = behavior;

                Debug.Log(GetType() + "()");
            }

            public override bool HandlesEvent(AbstractModelEvent mEvent)
            {
                if ( mEvent != null )
                {
                    SampleNamedModel named = mEvent.Source as SampleNamedModel;
                    return named != null;
                }

                return false;
            }

            protected override void ProcessEvent(AbstractModelEvent evt)
            {
                Debug.Log(GetType() + ".ProcessEvent");
                if (behavior != null)
                {
                    if (evt.Source != null)
                    {
                        SampleNamedModel named = evt.Source as SampleNamedModel;
                        if ( named != null )
                        {
                            behavior.GetComponent<Text>().text = named.FullName;
                        }
                    }
                }
            }

        }
    }

}
