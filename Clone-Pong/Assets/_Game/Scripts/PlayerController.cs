using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float speed = 5.0f;

    private bool ismoving = false;
    private Vector2 inputVector;

    public AudioClip hit;

    void FixedUpdate()
    {
        //Verificação 
        if (ismoving)
        {
            transform.position += new Vector3(0, inputVector.y * speed * Time.fixedDeltaTime, 0);
        }
    }

    //Método de controle do Sitema de Input
    public void Movement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        if (context.started)
            ismoving = true;

        if (context.canceled)
            ismoving = false;

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball"))
        {
            Master.Instance.audioController.TocarSfx(hit);
        }
    }

}
