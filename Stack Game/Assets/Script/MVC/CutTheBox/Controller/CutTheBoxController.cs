using Stack.Activator.Controller;
using Stack.Box.Controller;
using Stack.Calculate.Controller;
using Stack.Cut.Model;
using Stack.Cut.Pieces.Controller;
using Stack.Cut.View;
using Stack.Movement.Controller;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Stack.UI.Score.Controller;

namespace Stack.Cut.Controller
{
    public class CutTheBoxController : MonoBehaviour
    {
        private CutTheBoxModel _cutTheBoxModel;
        [SerializeField]
        private CutTheBoxView _cutTheBoxView;

        [SerializeField]
        private CalculateScaleController _calculateScaleController;
        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private ActivatorController _activatorController;
        [SerializeField]
        private MovementController _movementController;
        [SerializeField]
        private InstantiateBoxPiecesController _piecesController;
        [SerializeField]
        private ScoreController _scoreController;

        public Action OnAddScore;

        // Start is called before the first frame update
        void Start()
        {
            _cutTheBoxModel = new CutTheBoxModel();
            _cutTheBoxView.CutTheBoxModel = _cutTheBoxModel;

            _cutTheBoxView.BoxModel = _boxController.GetModel();
            _cutTheBoxView.ActivatorModel = _activatorController.GetModel();
            _cutTheBoxView.MovementModel = _movementController.GetModel();

            _calculateScaleController.OnFinishCalculate = (newScale, newPosition, pieceScale, piecePosition) =>
            {
                //Debug.Log(pieceScale + " " + piecePosition);
                _cutTheBoxModel.SetNewBoxScale(newScale);
                _cutTheBoxModel.SetNewBoxPosition(newPosition);
                _cutTheBoxModel.SetPieceScale(pieceScale);
                _cutTheBoxModel.SetPiecesPosition(piecePosition);
            };

            _calculateScaleController.OnCutTheBox = () =>
            {
                _cutTheBoxView.RescaleTheBox();
                _cutTheBoxView.CenterUpTheBox();
                OnAddScore();
                _scoreController.OnUpdateScoreText();
                _piecesController.OnActivatedPieces();
            };
        }

        public CutTheBoxModel GetModel()
        {
            return _cutTheBoxModel;
        }
    }

}