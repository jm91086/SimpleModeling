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
    [RequireComponent(typeof(Text))]
    public class TextChangeListener : PropertyChangeListener
    {
        protected override void ProcessEvent(AbstractModelEvent evt)
        {
            Debug.Log("PROCESSING EVENT: " + evt.NewValue);
            if (evt.NewType.Equals(typeof(string))) { 
                GetComponent<Text>().text = evt.NewValue as string;
            }
        }

    }

}
