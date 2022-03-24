using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int leftScore = 0;
    private int rightScore = 0;
    public Text leftScoreTxt;
    public Text rightScoreTxt;

    private void Awake() {
        leftScore = 0;
        rightScore=0;

        UpdateScore();
    }

    public void AddScore(int sideIndex){
        //sideIndex = 0 -> Lado Esquerdo(left)
        //sideIndex = 1 -> Lado Direito(right)

        if (sideIndex == 0)
        {
            leftScore+=1;
        }
        else{
            rightScore+=1;
        }
        UpdateScore();
    }

    private void UpdateScore(){
        leftScoreTxt.text = leftScore.ToString();
        rightScoreTxt.text = rightScore.ToString();
    }
}
