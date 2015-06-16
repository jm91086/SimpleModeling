using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace jwm.Model
{
    public abstract class PropertyChangeListener : AbstractModelListener
    {
        public string propertyName;
        public string PropertyName
        {
            get
            {
                return propertyName;
            }

            set
            {
                string oldName = propertyName;
                propertyName = value;
                NotifyListeners(new PropertyChangeEvent(this, "PropertyName", oldName, value));
            }
        }

        public override bool HandlesEvent(IModelEvent mEvent)
        {
            PropertyChangeEvent pce = mEvent as PropertyChangeEvent;
            return (pce != null && (string.IsNullOrEmpty(PropertyName) || pce.Property.Equals(PropertyName, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
