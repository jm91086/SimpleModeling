using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelList : AbstractModelCollection, IList<AbstractModel>
    {
        private List<AbstractModel> list;

        public List<AbstractModel> List
        {
            get
            {
                if ( list == null )
                {
                    list = new List<AbstractModel>();
                }

                return list;
            }
        }

        public void Add(AbstractModel value)
        {
            AddChildListener(value);

            List.Add(value);

            NotifyListeners(new ModelListAddEvent(this, List.Count - 1, value));
        }

        public void Clear()
        {
            foreach ( AbstractModel child in List )
            {
                RemoveChildListener(child);
            }

            List.Clear();

            NotifyListeners(new ModelListClearEvent(this));
        }

        public bool Contains(AbstractModel value)
        {
            return List.Contains(value);
        }

        public int IndexOf(AbstractModel value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, AbstractModel value)
        {
            AddChildListener(value);

            List.Insert(index, value);

            NotifyListeners(new ModelListAddEvent(this, index, value));
        }

        public bool Remove(AbstractModel value)
        {
            int index = IndexOf(value);

            if (index > -1)
            {
                RemoveChildListener(value);

                List.RemoveAt(index);

                NotifyListeners(new ModelListRemoveEvent(this, index, value));

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            AbstractModel value = List[index];

            if (value != null)
            {
                RemoveChildListener(value);

                List.RemoveAt(index);

                NotifyListeners(new ModelListRemoveEvent(this, index, value));
            }
        }

        public AbstractModel this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                AbstractModel oldValue = list[index];
                if ( oldValue != null )
                {
                    RemoveChildListener(oldValue);
                }

                if (value != null)
                {
                    AddChildListener(value);
                }

                List[index] = value;

                NotifyListeners(new ModelListSetEvent(this, index, oldValue, value));
            }
        }

        public void CopyTo(AbstractModel[] array, int index)
        {
            List.CopyTo(array, index);
        }

        public int Count
        {
            get { return List.Count; }
        }


        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<AbstractModel> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public override void CopyTo(AbstractModel model)
        {
            AbstractModelList list = model as AbstractModelList;
            if ( list != null )
            {
                list.List.Clear();
                list.List.AddRange(this.List);
                list.NotifyListeners(new ModelSetEvent(list));
            }
        }
    }
}
