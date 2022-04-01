using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource audioSourceSfx;
    

    void Start() {
        if (PlayerPrefs.GetInt("Sfx") == 0)
        {
            audioSourceSfx.mute = false;
        }
        else{
            audioSourceSfx.mute = true;
        }

        if (PlayerPrefs.GetInt("BGMusic") == 0)
        {
            backgroundMusic.mute = false;
        }
        else{
            backgroundMusic.mute = true;
        }

        float temp = PlayerPrefs.GetFloat("Volume");
        audioSourceSfx.volume =  temp;
        backgroundMusic.volume = temp;

    }


    public void TocarSfx(AudioClip clip){

        audioSourceSfx.PlayOneShot(clip);
    }

    public void MuteVolume(){
        // 0 = desmutado
        // 1 = mutado
        if (PlayerPrefs.GetInt("Sfx") == 0){
            PlayerPrefs.SetInt("Sfx",1);
            audioSourceSfx.mute = true;
        }
        if (PlayerPrefs.GetInt("Sfx") == 1){
            PlayerPrefs.SetInt("Sfx",0);
            audioSourceSfx.mute = false;
        }
    }

    public void MuteBGMusic(){
        // 0 = desmutado
        // 1 = mutado
        if (PlayerPrefs.GetInt("BGMusic") == 0){
            PlayerPrefs.SetInt("BGMusic",1);
            backgroundMusic.mute = true;
        }
        if (PlayerPrefs.GetInt("BGMusic") == 1){
            PlayerPrefs.SetInt("BGMusic",0);
            backgroundMusic.mute = false;
        }
    }

    public void SetVolume(){
        float volume = Master.Instance.gameController.sldVolume.value;
        audioSourceSfx.volume =  volume;
        backgroundMusic.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
    }
}
