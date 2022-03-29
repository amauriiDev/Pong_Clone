using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 30;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, Master.Instance.gameController.currentBall.transform.position.y * speed * Time.fixedDeltaTime, transform.position.z);
    }

}
