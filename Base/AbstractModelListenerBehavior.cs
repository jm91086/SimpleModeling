using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    [Serializable]
    public abstract class AbstractModelListenerBehavior<T> : MonoBehaviour where T : AbstractModel 
    {
        public AbstractModelBehavior ModelBehavior;

        void Start()
        {
            Debug.Log(GetType() + ".Start");
            if (ModelBehavior != null && ModelBehavior.Model != null && ((ModelBehavior.Model as T) != null))
            {
                Debug.Log(GetType() + ".Start: Adding Listener");
                ModelBehavior.Model.AddListener(GetModelListener());
            }
        }

        void Destroy()
        {
            Debug.Log(GetType() + ".Destroy");
            if (ModelBehavior != null && ModelBehavior.Model != null && ((ModelBehavior.Model as T) != null))
            {
                Debug.Log(GetType() + ".Destroy: Removing Listener");
                ModelBehavior.Model.RemoveListener(GetModelListener());
            }
        }

        abstract protected AbstractModelListener GetModelListener();
    }
}
