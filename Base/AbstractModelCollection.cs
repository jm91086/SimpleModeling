using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelCollection : AbstractModel, ICollection, IEnumerable, ICloneable
    {
        private ChildCollectionListener listener;
        protected ChildCollectionListener ChildListener
        {
            get
            {
                if ( listener == null )
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

            protected override void ProcessEvent(AbstractModelEvent mEvent)
            {
                Collection.NotifyListeners(new ModelCollectionChildEvent(Collection, mEvent));
            }

            protected override AbstractModel GetSource()
            {
                return Collection;
            }
        }

        public abstract void Add(AbstractModel item);

        public abstract void Clear();

        public abstract bool Contains(AbstractModel item);

        public abstract void CopyTo(AbstractModel[] array, int arrayIndex);

        public virtual int Count
        {
            get
            {
                return 0;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public abstract bool Remove(AbstractModel item);

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
