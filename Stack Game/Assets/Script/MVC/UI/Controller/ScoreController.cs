using Stack.Box.Controller;
using Stack.UI.Score.View;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.UI.Score.Controller
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private BoxController _boxController;
        [SerializeField]
        private ScoreView _scoreView;

        public Action OnUpdateScoreText;

        private void Start()
        {
            _scoreView.BoxModel = _boxController.GetModel();

            OnUpdateScoreText = () =>
            {
                _scoreView.SetScoreToText();
            };
        }
    }
}