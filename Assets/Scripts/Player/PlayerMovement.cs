using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputController controller;
    [SerializeField] float forwardMovementSpeed;
    [SerializeField] float horizontalMovementSpeed;
    [SerializeField] float horizontalRange;
    


    float playerXPosition;
    

    private void FixedUpdate()
    {
        PlayerForwardMovement();
        PlayerHorizontalMovement();
    }

    private void PlayerForwardMovement()
    {
        transform.Translate(forwardMovementSpeed * Time.fixedDeltaTime * Vector3.forward);

    }

    private void PlayerHorizontalMovement()
    {
        playerXPosition = Mathf.Clamp(transform.position.x + controller.horizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime, -horizontalRange, horizontalRange);
        transform.position = new Vector3(playerXPosition, transform.position.y, transform.position.z);
    }


}
