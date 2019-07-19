using Stack.Box.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stack.UI.Score.View
{
    public class ScoreView : MonoBehaviour
    {
        public BoxModel BoxModel;
        private Text _scoreText;

        private void Start()
        {
            _scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        public void SetScoreToText()
        {
            _scoreText.text = BoxModel.Score.ToString();
        }
    }
}
