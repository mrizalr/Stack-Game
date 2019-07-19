//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class StackView : StackElement
//{
//    public Text scoreText;
//    public Text GameOverText;

//    private void Update()
//    {
//        scoreText.text = app.model.boxStacked.ToString();

//        if (app.model.isGameOver)
//        {
//            scoreText.transform.parent.gameObject.SetActive(false);
//            GameOverText.gameObject.SetActive(true);

//            StartCoroutine(reloadGame());
//        }
//    }

//    IEnumerator reloadGame()
//    {
//        yield return new WaitForSeconds(2);

//        SceneManager.LoadScene(0);
//    }
//}
