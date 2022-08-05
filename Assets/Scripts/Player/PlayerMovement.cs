using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] string upAxis      = string.Empty;
    [SerializeField] string rightAxis   = string.Empty;
    [SerializeField] float rotationAmount = 15;
    
    float currentRotationVelocityRef = 0f;

    void Update()
    {
        transform.Translate
        (
            Input.GetAxis(rightAxis) * Time.deltaTime * speed,
            0,
            Input.GetAxis(upAxis) * Time.deltaTime * speed,
            Space.World
        );

        transform.rotation = Quaternion.Euler
        (
            0,
            0,
            Mathf.SmoothDampAngle
            (
                transform.eulerAngles.z,
                Input.GetAxis(rightAxis) * rotationAmount * -1,
                ref currentRotationVelocityRef,
                0.2f
            )
        );

        FitToScreen();
    }

    void FitToScreen()
    {
        Vector3 posInWorld = Camera.main.WorldToScreenPoint(transform.position);
        posInWorld.x = Mathf.Clamp(posInWorld.x, 22.8f, Screen.width);
        posInWorld.y = Mathf.Clamp(posInWorld.y, 20.0f, Screen.height);
        Vector3 posInScreen = Camera.main.ScreenToWorldPoint(posInWorld);
        transform.position = posInScreen;
    }

    bool IsPressingKeyFromArray(KeyCode[] keys)
    {
        bool isPressing = false;
        foreach(KeyCode k in keys)
        {
            isPressing |= Input.GetKey(k);
        }
        return isPressing;
    }
}
