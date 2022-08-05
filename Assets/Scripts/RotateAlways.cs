using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlways : MonoBehaviour
{
    public enum RotationAxis
    {
        X,Y,Z
    }

    [SerializeField] float speed = 45;
    [SerializeField] RotationAxis rotationAxis = RotationAxis.Y;

    void Update()
    {
        switch(rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(speed * Time.deltaTime, 0, 0);
                break;
            case RotationAxis.Y:
                transform.Rotate(0, speed * Time.deltaTime, 0);
                break;
            case RotationAxis.Z:
                transform.Rotate(0, 0, speed * Time.deltaTime);
                break;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
