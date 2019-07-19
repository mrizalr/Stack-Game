using Stack.Box.Controller;
using Stack.Generator.Model;
using Stack.Generator.View;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Generator.Controller
{
    public class GeneratorController : MonoBehaviour
    {
        private GeneratorModel _generatorModel;
        [SerializeField]
        private GeneratorView _generatorView;


        [SerializeField]
        private BoxController _boxController;

        public Action OnStoreInstantiatedBox;

        private float _groundHeight;
        private float _boxHeight;

        private void Awake()
        {
            _generatorModel = new GeneratorModel();
            _generatorModel.SetPrefabs();

            _generatorView.GeneratorModel = _generatorModel;
            _generatorView.BoxModel = _boxController.GetModel();

            _generatorView.OnStoreInstantiatedBox = OnStoreInstantiatedBox;

            _groundHeight = 0.7f;
            _boxHeight = 0.5f;

            _generatorView.OnAddHeightOfPosition = () =>
            {
                AddHeightPositon();
            };

            _generatorView.OnSetStarterBox = (starterBox, pieces) =>
            {
                _generatorModel.StarterBox = starterBox;
                _boxController.GetModel().BoxPieces = pieces;
            };

            _generatorView.StarterParent = GameObject.Find("environment").transform;
            _generatorView.GeneratorParent = GameObject.Find("Generator").transform;
            _generatorView.PiecesParent = GameObject.Find("Pieces").transform;

            _generatorView.GenerateStarter();
            _generatorView.GenerateBoxes();
        }

        public GeneratorModel GetModel()
        {
            return _generatorModel;
        }

        public GeneratorView GetView()
        {
            return _generatorView;
        }

        public void AddHeightPositon()
        {
            if (_generatorModel.InstantiatePosition.y <= 0)
            {
                _generatorModel.InstantiatePosition.y += _groundHeight;
            }
            else
            {
                _generatorModel.InstantiatePosition.y += _boxHeight;
            }
        }
    }

}