using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private bool ismoving = false;
    private Vector2 inputVector;
    private float speed = 5.0f;
    void Start()
    {
        //input = new PlayerInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ismoving)
        {
            transform.position += new Vector3(0, inputVector.y * speed * Time.fixedDeltaTime, 0);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        if (context.started)
            ismoving = true;

        if (context.canceled)
            ismoving = false;

    }

}
