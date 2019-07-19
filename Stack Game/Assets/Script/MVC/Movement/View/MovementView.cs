using Stack.Activator.Model;
using Stack.Box.Model;
using Stack.Movement.Model;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        public MovementModel MovementModel;
        public BoxModel BoxModel;
        public ActivatorModel ActivatorModel;

        public Action OnChangeCurrentPoint;
        public Action OnMoveBoxDown;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (BoxModel.isGameover)
            {
                return;
            }

            switch (MovementModel.con)
            {
                case MovementModel.Condition.Moving:
                    MoveBox();
                    break;
                case MovementModel.Condition.Stopped:
                    break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnMoveBoxDown();
            }            
        }

        void MoveBox()
        {
            Vector3 _movePoints = MovementModel.Points[MovementModel.CurrentPoint].transform.position;
            _movePoints.y = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position.y;

            if (BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position == _movePoints)
            {
                OnChangeCurrentPoint();
            }

            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position = Vector3.MoveTowards(BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position,
                _movePoints, MovementModel.Speed * Time.deltaTime);
        }
    }
}
