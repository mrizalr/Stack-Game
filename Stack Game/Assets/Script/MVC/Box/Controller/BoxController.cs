using Stack.Activator.Controller;
using Stack.Box.Model;
using Stack.Cut.Controller;
using Stack.Generator.Controller;
using Stack.Movement.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Box.Controller
{
    public class BoxController : MonoBehaviour
    {
        private BoxModel _boxModel = new BoxModel();

        [SerializeField]
        private GeneratorController _generatorController;
        [SerializeField]
        private MovementController _movementController;
        [SerializeField]
        private ActivatorController _activatorController;
        [SerializeField]
        private CutTheBoxController _cutTheBoxController;

        private void Awake()
        {
            //_boxModel = new BoxModel();

            _generatorController.OnStoreInstantiatedBox = () =>
            {
                _boxModel.ListOfBox.Add(_generatorController.GetView().BoxInstantiated);
            };

            _movementController.OnSetLastBox = () =>
            {
                SetLastBox(_boxModel.ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform);
            };

            _cutTheBoxController.OnAddScore = () =>
            {
                _boxModel.Score++;
            };
        }

        private void Start()
        {
            _boxModel.LastBox = _generatorController.GetModel().StarterBox;
        }

        public BoxModel GetModel()
        {
            return _boxModel;
        }

        public void SetLastBox(Transform box)
        {
            _boxModel.LastBox = box;
        }

        public void GameIsOver()
        {
            _boxModel.isGameover = true;
        }
    }
}
