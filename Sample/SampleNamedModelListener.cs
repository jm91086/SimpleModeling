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
    public class SampleNamedModelListener : PropertyChangeListener
    {
        public SampleNamedModelListener()
        {
        }

        protected override void ProcessEvent(AbstractModelEvent evt)
        {
            Debug.Log("PROCESSING EVENT");
            GetComponent<Text>().text = evt.NewValue as string;
        }

    }

}
