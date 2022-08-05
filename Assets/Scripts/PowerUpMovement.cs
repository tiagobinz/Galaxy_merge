using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    Vector3 direction;
    [SerializeField]
    float speed = 5;
    
    void Start()
    {
        Quaternion rotationDirection = Random.rotation;
        UpdateDirection(Quaternion.Euler(0, rotationDirection.eulerAngles.y, 0));
    }
    
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 22.8f || screenPos.x > Screen.width || screenPos.y < 20.0f || screenPos.y > Screen.height)
        {
            UpdateDirection(Quaternion.LookRotation(Quaternion.Euler(0, Random.Range(135f, 225f), 0) * direction));
        }
    }

    void UpdateDirection(Quaternion rotationDirection)
    {
        direction = rotationDirection * Vector3.forward;
    }
}
