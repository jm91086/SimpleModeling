using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    [Serializable]
    public abstract class ModelReference<T> where T : AbstractModel
    {
        protected string uid;

        public string UID
        {
            get
            {
                return uid;
            }

            set
            {
                uid = value;
            }
        }
    }
}
