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

    public Sprite[] imgSongs;
    public Sprite[] imgBGMusic;


    public Slider sldVolume;
    public GameObject pnlConfig;
    public GameObject pnlMainMenu;

    private void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex) == 0)
        {
            sldVolume.value = PlayerPrefs.GetFloat("Volume");
        }
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

    //Carregar cena passada por parâmetro
    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetBGAudio(Image img)
    {
        if (Master.Instance.audioController.backgroundMusic.mute)
        {
            img.sprite = imgBGMusic[1];
        }
        else
        {
             Debug.Log("Desmutado");
            img.sprite = imgBGMusic[0];
        }
    }
    public void SetSFXAudio(Image img)
    {

        if (Master.Instance.audioController.audioSourceSfx.mute)
        {
            img.sprite = imgSongs[1];
        }
        else
        {
            img.sprite = imgSongs[0];
        }
    }

    public void SetActivePanel(string name)
    {
        pnlConfig.SetActive(false);
        pnlMainMenu.SetActive(false);

        if (name == "config")
            pnlConfig.SetActive(true);

        if (name == "menu")
            pnlMainMenu.SetActive(true);
    }
}
