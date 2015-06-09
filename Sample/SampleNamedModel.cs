using jwm.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public class SampleNamedModel : AbstractModel
    {
        public static readonly string PRP_FULLNAME = "FullName";
        protected string fullName;

        public string FullName
        {
            get 
            {
                return fullName;
            }
            set 
            {
                string oldName = fullName;
                fullName = value;
                NotifyListeners(new PropertyChangeEvent(this, PRP_FULLNAME, oldName, value));
            }
        }

    }
}
