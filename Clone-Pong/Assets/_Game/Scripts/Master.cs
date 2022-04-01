using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    #region Singleton
    private static Master instance;
    public static Master Instance { get { return instance; } }

    private void Awake() {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    #endregion

    public GameController gameController {get; private set;}
    public AudioController audioController {get; private set;}

    void Start() {
        gameController = GetComponentInChildren<GameController>();
        audioController = GetComponentInChildren<AudioController>();
    }
}
