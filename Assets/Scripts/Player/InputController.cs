using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{


    public float horizontalValue { get; private set;}




    void Update()
    {
        HorizontalInput();
    }


    private void HorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {

            horizontalValue = Input.GetAxis("Mouse X");
        }
        else 
        {
            horizontalValue = 0;
        }

    }
}
