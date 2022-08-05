using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : MonoBehaviour
{
    [SerializeField] Vector3 position = Vector3.zero;
    [SerializeField] int smoothTime = 2;
    [SerializeField] bool x = true, y = true, z = true;

    Vector3 currentVelocityRef;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3
            (
                x ? position.x : transform.position.x,
                y ? position.y : transform.position.y,
                z ? position.z : transform.position.z
            ),
            ref currentVelocityRef,
            smoothTime
        );
    }

    public bool IsAtPosition()
    {
        return (transform.position - position).magnitude < 1f;
    }
}
