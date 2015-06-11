using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModelListListener : AbstractModelListener
    {
        protected Dictionary<AbstractModel, object> objectMap = null;

        public AbstractModelListListener()
        {
            Debug.Log(GetType() + "()");
            this.objectMap = new Dictionary<AbstractModel, object>();
        }

        public override bool HandlesEvent(AbstractModelEvent mEvent)
        {
            Debug.Log(GetType() + ".HandlesEvent: " + mEvent.GetType());

            if (mEvent != null)
            {
                AbstractModelList list = mEvent.Source as AbstractModelList;
                return list != null;
            }

            return false;
        }

        public override void ReceiveEvent(AbstractModelEvent mEvent)
        {
            Debug.Log(GetType() + ".ReceiveEvent");
            if ( HandlesEvent(mEvent) )
            {
                ProcessEvent(mEvent);
                ProcessModelSetEvent(mEvent as ModelSetEvent);
                ProcessModelListAddEvent(mEvent as ModelListAddEvent);
                ProcessModelListRemoveEvent(mEvent as ModelListRemoveEvent);
                ProcessModelListClearEvent(mEvent as ModelListClearEvent);
                ProcessModelCollectionChildEvent(mEvent as ModelCollectionChildEvent);
            }

        }

        protected override void ProcessEvent(AbstractModelEvent evt)
        {
            //Do nothing
        }

        virtual protected void ProcessModelCollectionChildEvent(ModelCollectionChildEvent mEvent)
        {
            //Do nothing
        }

        protected void ProcessModelSetEvent(ModelSetEvent mEvent)
        {
            if (mEvent == null)
            {
                return;
            }

            ClearModels();

            AbstractModelList list = mEvent.Source as AbstractModelList;
            foreach (AbstractModel model in list)
            {
                objectMap.Add(model, AddModel(model));
            }
        }

        protected void ProcessModelListAddEvent(ModelListAddEvent mEvent)
        {
            if (mEvent == null)
            {
                return;
            }

            AbstractModel model = mEvent.Value as AbstractModel;

            if (!objectMap.ContainsKey(model))
            {
                AddModel(model);
            }
        }

        protected void ProcessModelListRemoveEvent(ModelListRemoveEvent mEvent)
        {
            if (mEvent == null)
            {
                return;
            }

            AbstractModel model = mEvent.Value as AbstractModel;
            if ( objectMap.ContainsKey(model) )
            {
                RemoveModel(model);

                objectMap.Remove(model);
            }
        }

        protected void ProcessModelListClearEvent(ModelListClearEvent mEvent)
        {
            if (mEvent == null)
            {
                return;
            }

            objectMap.Clear();

            ClearModels();
        }

        abstract protected object AddModel(AbstractModel model);

        abstract protected void RemoveModel(AbstractModel model);

        abstract protected void ClearModels();

    }
}
