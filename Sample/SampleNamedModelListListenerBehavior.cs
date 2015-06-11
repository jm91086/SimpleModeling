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
    public class SampleNamedModelListListenerBehavior : AbstractModelListenerBehavior<SampleNamedModelList>
    {
        public GameObject RowList = null;
        public GameObject RowPrefab = null;

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

        protected class MyListener : AbstractModelListListener
        {
            protected SampleNamedModelListListenerBehavior behavior = null;

            public MyListener(SampleNamedModelListListenerBehavior behavior)
                :base()
            {
                Debug.Log(GetType() + "()");
                this.behavior = behavior;
            }

            public override bool HandlesEvent(AbstractModelEvent mEvent)
            {
                Debug.Log(GetType() + ".HandlesEvent: " + mEvent.GetType());

                if ( mEvent != null )
                {
                    SampleNamedModelList namedList = mEvent.Source as SampleNamedModelList;
                    return namedList != null;
                }

                return false;
            }

            override protected object AddModel(AbstractModel model)
            {
                GameObject go = GameObject.Instantiate(behavior.RowPrefab) as GameObject;
                SampleNamedModelBehavior[] children = go.GetComponentsInChildren<SampleNamedModelBehavior>();
                foreach ( SampleNamedModelBehavior child in children )
                {
                    child.Model = model;
                }
                go.transform.SetParent(behavior.RowList.transform);

                return go;
            }

            override protected void RemoveModel(AbstractModel model)
            {
                GameObject.Destroy(objectMap[model] as GameObject);
            }

            override protected void ClearModels()
            {
                foreach( Transform child in behavior.RowList.transform )
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

            
        }
    }

}
