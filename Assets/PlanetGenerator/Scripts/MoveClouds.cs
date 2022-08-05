using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    [SerializeField]
    float speedX = 0, speedY = 0;

    const string propertyName = "_cloudsMovement";

    Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        mat.SetVector
        (
            propertyName,
            new Vector4
            (
                mat.GetVector(propertyName).x + speedX * Time.deltaTime,
                mat.GetVector(propertyName).y + speedY * Time.deltaTime
            )
        );
    }
}
