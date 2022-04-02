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

    public Image imgSong;
    public Image imgBGMusic;
    public Sprite[] imgSongs;
    public Sprite[] imgBGMusics;


    public Slider sldVolume;
    public GameObject pnlConfig;
    public GameObject pnlMainMenu;
    public GameObject pnlPause;

    public AudioClip scoreSfx;

    private void Start()
    {
        if ((SceneManager.GetActiveScene().buildIndex) == 0)
        {
            sldVolume.value = PlayerPrefs.GetFloat("Volume");
            SetSFXAudio();
            SetBGAudio();
        }
        if ((SceneManager.GetActiveScene().buildIndex) == 1)
        {

            currentBall = FindObjectOfType<Ball>().gameObject;
            leftScore = 0;
            rightScore = 0;

            UpdateScore();
            ResumeGame();
        }
    }


    public void AddScore(int sideIndex)
    {
        //sideIndex = 0 -> Lado Esquerdo(left)
        //sideIndex = 1 -> Lado Direito(right)

        Master.Instance.audioController.TocarSfx(scoreSfx);
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
        pnlPause.SetActive(true);
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
    }
    public void ResumeGame()
    {
        pnlPause.SetActive(false);
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetBGAudio()
    {
        imgBGMusic.sprite = imgBGMusics[PlayerPrefs.GetInt("BGMusic")];
        // if (Master.Instance.audioController.backgroundMusic.mute)
        // {
        //     imgBGMusic.sprite = imgBGMusics[1];
        // }
        // else
        // {
        //     imgBGMusic.sprite = imgBGMusics[0];
        // }
    }
    public void SetSFXAudio()
    {
        imgSong.sprite = imgSongs[PlayerPrefs.GetInt("Sfx")];
        // if (Master.Instance.audioController.audioSourceSfx.mute)
        // {
        //     imgSong.sprite = imgSongs[1];
        // }
        // else
        // {
        //     imgSong.sprite = imgSongs[0];
        // }
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
