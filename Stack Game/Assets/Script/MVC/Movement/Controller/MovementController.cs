using Stack.Activator.Controller;
using Stack.Box.Controller;
using Stack.Movement.Model;
using Stack.Movement.View;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Movement.Controller
{
    public class MovementController : MonoBehaviour
    {
        private MovementModel _movementModel;
        [SerializeField]
        private MovementView _movementView;

        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private ActivatorController _activatorController;

        private Transform[] _patrolsChild;

        public Action OnAddNewBox;
        public Action OnSetLastBox;
        public Action OnCalculate;

        private void Awake()
        {
            _movementModel = new MovementModel();
            _movementModel.Patrols = GameObject.FindGameObjectWithTag("Patrol");

            SetPatrols();
        }

        // Start is called before the first frame update
        void Start()
        {
            _movementView.MovementModel = _movementModel;
            _movementView.BoxModel = _boxController.GetModel();
            _movementView.ActivatorModel = _activatorController.GetModel();

            _movementView.OnChangeCurrentPoint = () =>
            {
                ChangeCurrentPointPosition();
            };

            _movementView.OnMoveBoxDown = () =>
            {
                MoveBoxDown();
            };
        }

        public MovementModel GetModel()
        {
            return _movementModel;
        }

        void ChangeCurrentPointPosition()
        {
            switch (_movementModel.CurrentPoint)
            {
                case 0:
                    _movementModel.CurrentPoint = 1;
                    break;
                case 1:
                    _movementModel.CurrentPoint = 0;
                    break;
                case 2:
                    _movementModel.CurrentPoint = 3;
                    break;
                case 3:
                    _movementModel.CurrentPoint = 2;
                    break;
            }
        }

        void SetPatrols()
        {
            int i=0;
            foreach (Transform child in _movementModel.Patrols.transform)
            {
                _movementModel.Points[i] = child;
                i++;
            }
        }

        void MoveBoxDown()
        {
            OnCalculate();

            _movementModel.con = MovementModel.Condition.Stopped;
            SwitchDirection();

            OnSetLastBox();
            OnAddNewBox();
            _movementModel.con = MovementModel.Condition.Moving;
        }

        void SwitchDirection()
        {
            switch (_movementModel.CurrentPatrols)
            {
                case 0:
                    _movementModel.CurrentPatrols = 1;
                    _movementModel.CurrentPoint = 2;

                    ChangePoint();
                    break;
                case 1:
                    _movementModel.CurrentPatrols = 0;
                    _movementModel.CurrentPoint = 0;

                    ChangePoint();
                    break;
            }
        }

        void ChangePoint()
        {
            Vector3 newPos = new Vector3(0,0,0);
            switch (_movementModel.CurrentPatrols)
            {
                case 0:
                    newPos = _movementModel.Points[0].position;
                    newPos.z = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.position.z;
                    _movementModel.Points[0].position = newPos;

                    newPos = _movementModel.Points[1].position;
                    newPos.z = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.position.z;
                    _movementModel.Points[1].position = newPos;
                    break;
                case 1:
                    newPos = _movementModel.Points[2].position;
                    newPos.x = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.position.x;
                    _movementModel.Points[2].position = newPos;

                    newPos = _movementModel.Points[3].position;
                    newPos.x = _boxController.GetModel().ListOfBox[_activatorController.GetModel().CurrentActiveBox].transform.position.x;
                    _movementModel.Points[3].position = newPos;
                    break;
            }
        }
    }
}
