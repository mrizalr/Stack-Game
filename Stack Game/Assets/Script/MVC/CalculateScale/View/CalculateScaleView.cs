using Stack.Activator.Model;
using Stack.Box.Model;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Stack.Movement.Model;

namespace Stack.Calculate.View
{
    public class CalculateScaleView : MonoBehaviour
    {
        public BoxModel BoxModel;
        public ActivatorModel ActivatorModel;
        public MovementModel MovementModel;

        private float _dist;

        public Action OnReadyToCalculate;
        public Action OnGameover;

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            _dist = Vector3.Distance(BoxModel.LastBox.position, BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position);
        }

        public void CheckingPositon()
        {
            float distLimit = 0;

            if (MovementModel.CurrentPatrols == 0)
            {
                distLimit = BoxModel.LastBox.localScale.x;
            }
            else if (MovementModel.CurrentPatrols == 1)
            {
                distLimit = BoxModel.LastBox.localScale.z;
            }

            if (_dist > distLimit)
            {
                OnGameover();
                BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].GetComponent<Rigidbody>().isKinematic = false;
                return;
            }

            OnReadyToCalculate();
        }

        public bool isGreater(Vector3 checkObject, Vector3 target)
        {
            if (checkObject.x > target.x || checkObject.z > target.z)
            {
                return true;
            }

            return false;
        }
    }
}