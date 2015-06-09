using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace jwm.Model
{
    public abstract class AbstractModelMap : AbstractModelCollection, IDictionary<string, AbstractModel>
    {
        private Dictionary<string, AbstractModel> dictionary;

        protected Dictionary<string, AbstractModel> Map
        {
            get
            {
                if ( dictionary == null )
                {
                    dictionary = new Dictionary<string, AbstractModel>();
                }
                return dictionary;
            }
        }


        public void Add(string key, AbstractModel value)
        {
            AddChildListener(value);

            Map.Add(key, value);

            NotifyListeners(new ModelMapAddEvent(this, key, value));
        }

        public override void Clear()
        {
            foreach (AbstractModel child in Map.Values)
            {
                RemoveChildListener(child);
            }

            Map.Clear();

            NotifyListeners(new ModelMapClearEvent(this));
        }

        public override bool Contains(AbstractModel value)
        {
            return Map.ContainsValue(value);
        }
        
        public ICollection Keys
        {
            get { return Map.Keys; }
        }


        public ICollection Values
        {
            get { return Map.Values; }
        }

        public AbstractModel this[string key]
        {
            get
            {
                return Map[key];
            }
            set
            {
                AbstractModel oldChild = Map[key];
                if ( oldChild != null )
                {
                    RemoveChildListener(oldChild);
                }

                AddChildListener(value);

                Map[key] = value;

                NotifyListeners(new ModelMapSetEvent(this, key, oldChild, value));
            }
        }

        public override int Count
        {
            get { return Map.Count; }
        }

        public bool ContainsKey(string key)
        {
            return Map.ContainsKey(key);
        }

        ICollection<string> IDictionary<string, AbstractModel>.Keys
        {
            get { return Map.Keys; }
        }

        public bool Remove(string key)
        {
            AbstractModel oldChild = Map[key];
            
            if (oldChild != null)
            {
                RemoveChildListener(oldChild);
            }

            bool toRet = Map.Remove(key);

            if ( toRet )
            {
                NotifyListeners(new ModelMapRemoveEvent(this, key, oldChild));
            }

            return toRet;
        }

        public bool TryGetValue(string key, out AbstractModel value)
        {
            return Map.TryGetValue(key, out value);
        }

        ICollection<AbstractModel> IDictionary<string, AbstractModel>.Values
        {
            get { return Map.Values; }
        }

        public void Add(KeyValuePair<string, AbstractModel> item)
        {
            this.Add(item.Key, item.Value);
        }

        public bool Contains(KeyValuePair<string, AbstractModel> item)
        {
            return Map.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, AbstractModel>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, AbstractModel> item)
        {
            return this.Remove(item.Key);
        }

        public new IEnumerator<KeyValuePair<string, AbstractModel>> GetEnumerator()
        {
            return Map.GetEnumerator();
        }
    }
}
