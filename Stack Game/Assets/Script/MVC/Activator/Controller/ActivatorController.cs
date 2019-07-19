using Stack.Activator.Model;
using Stack.Activator.View;
using Stack.Box.Controller;
using Stack.Generator.Controller;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Stack.Movement.Controller;

namespace Stack.Activator.Controller
{
    public class ActivatorController : MonoBehaviour
    {
        private ActivatorModel _activatorModel;
        [SerializeField]
        private ActivatorView _activatorView;

        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private GeneratorController _generatorController;
        [SerializeField]
        private MovementController _movementController;

        public Action OnAddHeightPosition;

        private void OnEnable()
        {
            _activatorModel = new ActivatorModel();

            _activatorView.ActivatorModel = _activatorModel;
            _activatorView.BoxModel = _boxController.GetModel();
            _activatorView.GeneratorModel = _generatorController.GetModel();
            _activatorView.MovementModel = _movementController.GetModel();


            #region Activator View Callback

            _activatorView.OnAddHeigtOfPosition = () =>
            {
                _generatorController.AddHeightPositon();
            };

            _activatorView.OnAddDeactiveBoxIndex = () =>
            {
                if (!_activatorModel.isReadytoDeactived)
                {
                    _activatorModel.isReadytoDeactived = true;
                }

                if (_activatorModel.IndexBoxDeactivated == _boxController.GetModel().ListOfBox.Count - 1)
                {
                    _activatorModel.IndexBoxDeactivated = 0;
                }
                else
                {
                    _activatorModel.IndexBoxDeactivated++;
                }
            };

            _activatorView.OnBoxActived = () =>
            {
                _activatorModel.isReadyForNewBox = false;
            };

            #endregion
            #region Movement Controller Callback

            _movementController.OnAddNewBox = () =>
            {
                if (_activatorModel.CurrentActiveBox == _boxController.GetModel().ListOfBox.Count - 1)
                {
                    _activatorModel.CurrentActiveBox = 0;
                }
                else
                {
                    _activatorModel.CurrentActiveBox++;
                }
                _activatorModel.isReadyForNewBox = true;
            };

            #endregion
        }

        public ActivatorModel GetModel()
        {
            return _activatorModel;
        }
    }
}
