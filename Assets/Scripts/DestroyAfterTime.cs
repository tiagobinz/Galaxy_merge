using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float lifeTime = 5;

    float timer;
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
