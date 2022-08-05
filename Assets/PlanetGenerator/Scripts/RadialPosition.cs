using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPosition : MonoBehaviour
{
    Transform planetTransform = null;
    float planetDistance;
    
    void Start()
    {
        planetTransform = Object.FindObjectOfType<Planet>().transform;
        planetDistance = Mathf.Abs(planetTransform.position.y);
    }

    void LateUpdate()
    {
        Vector3 fromPlanetToMe = (transform.position - planetTransform.position).normalized;
        print(fromPlanetToMe);
        transform.position = planetTransform.position + fromPlanetToMe * planetDistance;
        //Quaternion lookRotation = Quaternion.LookRotation(fromPlanetToMe);
        //transform.rotation = lookRotation;
    }
}
