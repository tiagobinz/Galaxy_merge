using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongRotation : MonoBehaviour
{
    [SerializeField] float rotationAmount = 15;
    [SerializeField] float rotationSpeed = 1;

    Quaternion A;
    Quaternion B;
    float currentAlpha = 0.5f;

    void Start()
    {
        A = Quaternion.Euler(0, transform.eulerAngles.y - rotationAmount, 0);
        B = Quaternion.Euler(0, transform.eulerAngles.y + rotationAmount, 0);
    }

    void Update()
    {
        currentAlpha += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(A, B, Mathf.PingPong(currentAlpha, 1));
    }
}
