using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject currentBall;
    private int leftScore = 0;
    private int rightScore = 0;
    public Text leftScoreTxt;
    public Text rightScoreTxt;

    private void Awake()
    {
        if ((SceneManager.GetActiveScene().buildIndex) == 1)
        {

            currentBall = FindObjectOfType<Ball>().gameObject;
            leftScore = 0;
            rightScore = 0;

            UpdateScore();
        }
    }

    public void AddScore(int sideIndex)
    {
        //sideIndex = 0 -> Lado Esquerdo(left)
        //sideIndex = 1 -> Lado Direito(right)

        if (sideIndex == 0)
        {
            leftScore += 1;
        }
        else
        {
            rightScore += 1;
        }

        UpdateScore();
        Run();

        //Fim do jogo
        if (leftScore > 9 || rightScore > 9)
        {
            SceneLoad("Menu");
        }
    }

    //Atualizar placar
    private void UpdateScore()
    {
        leftScoreTxt.text = leftScore.ToString();
        rightScoreTxt.text = rightScore.ToString();
    }

    // Instanciar uma outra bola para outra rodada
    public void Run()
    {
        currentBall = Instantiate(ball, Vector3.forward, Quaternion.identity);
    }

    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
