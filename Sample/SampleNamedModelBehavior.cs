using jwm.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    [Serializable]
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


        public override void CopyTo(AbstractModel model)
        {
            SampleNamedModel named = model as SampleNamedModel;
            if (named != null)
            {
                named.fullName = this.fullName;
                named.NotifyListeners(new ModelSetEvent(named));
            }
        }

    }

    public class SampleNamedModelBehavior : AbstractModelBehavior
    {
        public string InitialName = "Zero";
        public SampleNamedModel NamedModel
        {
            get
            {
                return model as SampleNamedModel;
            }
        }

        override protected void InitializeModel()
        {
            SampleNamedModel sampleModel = new SampleNamedModel();

            sampleModel.FullName = InitialName;

            this.model = sampleModel;
        }


        public void SetName(string name)
        {
            NamedModel.FullName = name;
        }
    }
}
