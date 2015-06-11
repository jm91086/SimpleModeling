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
    [Serializable]
    public class SampleNamedModelList : AbstractModelList
    {
    }

    public class SampleNamedModelListBehavior : AbstractModelBehavior
    {
        public InputField InputField = null;

        public SampleNamedModelList NamedModelList
        {
            get
            {
                return model as SampleNamedModelList;
            }
        }

        override protected void InitializeModel()
        {
            SampleNamedModelList modelList = new SampleNamedModelList();

            this.model = modelList;
        }

        public void AddNamedModel()
        {
            if ( InputField != null )
            {
                SampleNamedModel sampleModel = new SampleNamedModel();
                sampleModel.FullName = InputField.text;
                NamedModelList.Add(sampleModel);
            }
        }

        public void ClearNamedModels()
        {
            NamedModelList.Clear();
        }

        public void RemoveNamedModel(SampleNamedModel model)
        {
            NamedModelList.Remove(model);
        }
    }
}
