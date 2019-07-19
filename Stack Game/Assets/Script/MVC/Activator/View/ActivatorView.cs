using Stack.Activator.Model;
using Stack.Box.Model;
using Stack.Generator.Model;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Stack.Movement.Model;

namespace Stack.Activator.View
{
    public class ActivatorView : MonoBehaviour
    {
        public ActivatorModel ActivatorModel;
        public BoxModel BoxModel;
        public GeneratorModel GeneratorModel;
        public MovementModel MovementModel;

        private GameObject _currentBox;
        private Material _boxColor;

        public Action OnAddHeigtOfPosition;
        public Action OnAddDeactiveBoxIndex;
        public Action OnBoxActived;

        // Update is called once per frame
        void Update()
        {
            if (BoxModel.isGameover)
            {
                return;
            }

            if (ActivatorModel.isReadyForNewBox)
            {
                ActivateTheBox();
                DeactivateBox();
            }
        }

        void ActivateTheBox()
        {
            Vector3 _newInstantiatePosition;
            _newInstantiatePosition = GeneratorModel.InstantiatePosition;
            _newInstantiatePosition.x = MovementModel.Points[MovementModel.CurrentPoint].transform.position.x;
            _newInstantiatePosition.z = MovementModel.Points[MovementModel.CurrentPoint].transform.position.z;

            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position = _newInstantiatePosition;
            _boxColor = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].GetComponent<Renderer>().material;
            _boxColor.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));

            ResizeNewBox();
            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].SetActive(true);
            OnAddHeigtOfPosition();

            OnBoxActived();
        }

        void DeactivateBox()
        {
            if (ActivatorModel.CurrentActiveBox >= 10)
            {
                BoxModel.ListOfBox[ActivatorModel.IndexBoxDeactivated].SetActive(false);
                OnAddDeactiveBoxIndex();
            }
        }

        void ResizeNewBox()
        {
            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale = BoxModel.LastBox.localScale;
        }
    }
}