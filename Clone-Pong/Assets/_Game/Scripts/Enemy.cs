using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float speed = 30;
    public AudioClip hit;

    void FixedUpdate()
    {
        //A posição será a atual posição nos eixos X e Z, e a posição da bola no eixo Y
        transform.position = new Vector3(transform.position.x, Master.Instance.gameController.currentBall.transform.position.y * speed * Time.fixedDeltaTime, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Efeito sonoro, apenas somente
            Master.Instance.audioController.TocarSfx(hit);
        }
    }
}
