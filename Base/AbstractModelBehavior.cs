using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace jwm.Model
{
    public abstract class AbstractModelBehavior : MonoBehaviour
    {
        [SerializeField]
        protected AbstractModel model;

        public AbstractModel Model
        {
            get {
                return model;
            }

            set
            {
                value.CopyTo(model);
            }
        }

        void Awake()
        {
            Debug.Log(GetType() + ".Awake");

            InitializeModel();

            if ( model == null )
            {
                throw new System.Exception(GetType().Name + " has a null model.");
            }
        }

        void Start()
        {
            Model.NotifyListeners(new ModelSetEvent(Model));
        }

        abstract protected void InitializeModel();
    }
}
