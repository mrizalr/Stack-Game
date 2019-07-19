using Stack.Box.Controller;
using Stack.Cut.Controller;
using Stack.Cut.Pieces.View;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Stack.Activator.Controller;
using Stack.Movement.Controller;

namespace Stack.Cut.Pieces.Controller
{
    public class InstantiateBoxPiecesController : MonoBehaviour
    {
        [SerializeField]
        private CutTheBoxController _cutTheBoxController;
        [SerializeField]
        private InstantiateBoxPiecesView _boxPiecesView;
        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private ActivatorController _activatorController;
        [SerializeField]
        private MovementController _movementController;

        public Action OnActivatedPieces;

        private void Start()
        {
            _boxPiecesView.CutTheBoxModel = _cutTheBoxController.GetModel();
            _boxPiecesView.BoxModel = _boxController.GetModel();
            _boxPiecesView.ActivatorModel = _activatorController.GetModel();
            _boxPiecesView.MovementModel = _movementController.GetModel();

            OnActivatedPieces = () =>
            {
                _boxPiecesView.InstantiateNewPieces();
            };
        }
    }
}