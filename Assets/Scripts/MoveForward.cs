using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
