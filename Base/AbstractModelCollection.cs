using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelCollection : AbstractModel
    {
        private ChildCollectionListener listener;
        protected ChildCollectionListener ChildListener
        {
            get
            {
                if (listener == null)
                {
                    listener = new ChildCollectionListener(this);
                }

                return listener;
            }
        }

        public void AddChildListener(AbstractModel model)
        {
            model.AddListener(ChildListener);
        }

        public void RemoveChildListener(AbstractModel model)
        {
            model.RemoveListener(ChildListener);
        }


        public class ChildCollectionListener : AbstractModelListener
        {
            public AbstractModelCollection Collection
            {
                private set;
                get;
            }

            public ChildCollectionListener(AbstractModelCollection collection)
                : base()
            {
                Collection = collection;
            }

            public override void ProcessEvent(IModelEvent mEvent)
            {
                AbstractModelEvent ame = mEvent as AbstractModelEvent;
                if ( ame != null )
                { 
                    Collection.NotifyListeners(new ModelCollectionChildEvent(Collection, ame));
                }
            }

        }
    }
        
}
