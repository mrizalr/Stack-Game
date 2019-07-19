using Stack.Activator.Controller;
using Stack.Box.Controller;
using Stack.Calculate.View;
using Stack.Cut.Controller;
using Stack.Movement.Controller;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Calculate.Controller
{
    public class CalculateScaleController : MonoBehaviour
    {
        [SerializeField]
        private CalculateScaleView _calculateScaleView;
        [SerializeField]
        private CutTheBoxController _cutTheBoxController;
        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private ActivatorController _activatorController;
        [SerializeField]
        private MovementController _movementController;

        private Vector3 _lastBoxPositon;
        private Vector3 _lastBoxRad;
        private Vector3 _activeBoxPositon;
        private Vector3 _activeBoxRad;

        public Action<Vector3, Vector3, Vector3, Vector3> OnFinishCalculate;
        public Action OnCutTheBox;

        private void Start()
        {
            _calculateScaleView.BoxModel = _boxController.GetModel();
            _calculateScaleView.ActivatorModel = _activatorController.GetModel();
            _calculateScaleView.MovementModel = _movementController.GetModel();

            _calculateScaleView.OnReadyToCalculate = () =>
            {
                CalculateScale();
            };

            _calculateScaleView.OnGameover = () =>
            {
                _boxController.GameIsOver();
            };

            _movementController.OnCalculate = () =>
            {
                _calculateScaleView.CheckingPositon();
            };
        }

        void CalculateScale()
        {
            _lastBoxPositon = _boxController.GetModel().LastBox.position; //bottomboxpos
            _lastBoxRad = _boxController.GetModel().LastBox.localScale/2; //bottomboxsize
            _activeBoxPositon = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.position; //topboxpos
            _activeBoxRad = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.localScale/2; //topboxsize

            if (_calculateScaleView.isGreater(_activeBoxPositon, _lastBoxPositon))
            {
                Vector3 _lastBoxVertex = _lastBoxPositon + _lastBoxRad;
                Vector3 _activeBoxVertex = _activeBoxPositon - _activeBoxRad;
                Vector3 _newScale = _lastBoxVertex - _activeBoxVertex;
                Vector3 _newPosition = _activeBoxRad - _newScale / 2;
                Vector3 _boxPieceSize = _boxController.GetModel().LastBox.transform.localScale - _newScale;
                Vector3 _piecePosition = _lastBoxVertex + _boxPieceSize / 2;

                OnFinishCalculate(_newScale, (_activeBoxPositon - _newPosition), _boxPieceSize, _piecePosition);
                OnCutTheBox();

            }
            else
            {
                Vector3 _lastBoxVertex = _lastBoxPositon - _lastBoxRad;
                Vector3 _activeBoxVertex = _activeBoxPositon + _activeBoxRad;
                Vector3 _newScale = _activeBoxVertex - _lastBoxVertex;
                Vector3 _newPosition = _activeBoxRad - _newScale / 2;
                Vector3 _boxPieceSize = _boxController.GetModel().LastBox.transform.localScale - _newScale;
                Vector3 _piecePosition = _lastBoxVertex - _boxPieceSize / 2;

                OnFinishCalculate(_newScale, (_activeBoxPositon + _newPosition), _boxPieceSize, _piecePosition);
                OnCutTheBox();

                //app.model.boxList[app.model.boxStacked - 1].transform.localScale = new Vector3(cutValue,
                //    app.model.boxList[app.model.boxStacked - 1].transform.localScale.y,
                //    app.model.boxList[app.model.boxStacked - 1].transform.localScale.z);

                //app.model.boxList[app.model.boxStacked - 1].transform.position = new Vector3(app.model.boxList[app.model.boxStacked - 1].transform.position.x + slideValue,
                //    app.model.boxList[app.model.boxStacked - 1].transform.position.y,
                //    app.model.boxList[app.model.boxStacked - 1].transform.position.z);

                //InstantiateCutObject(cutX, cutValue, bottomSideVertex - cutX / 2);
            }
        }

    }
}
