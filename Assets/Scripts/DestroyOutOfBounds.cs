using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float extraBounds = 100;

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 22.8f - extraBounds || screenPos.x > Screen.width + extraBounds)
        {
            Destroy(gameObject);
        }
        if (screenPos.y < 20.0f - extraBounds || screenPos.y > Screen.height + extraBounds)
        {
            Destroy(gameObject);
        }
    }
}
