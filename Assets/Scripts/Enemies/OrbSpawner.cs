using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] float interval = 0.75f;
    [SerializeField] int orbCount = 15;
    [SerializeField] GameObject orb = null;
    [SerializeField] float rotationSpeed = 30;
    
    void Start()
    {
        StartCoroutine(SpawnOrbs());
    }

    IEnumerator SpawnOrbs()
    {
        for (int i = 0; i < orbCount; i++)
        {
            SpawnOrb();
            yield return new WaitForSeconds(interval);
        }
        Destroy(gameObject);
    }

    void SpawnOrb()
    {
        if (orb)
        {
            GameObject newOrb = Instantiate(orb, transform.position, transform.rotation);
            RotateAlways r = newOrb.GetComponent<RotateAlways>();
            if (r)
            {
                r.SetSpeed(rotationSpeed);
            }
        }
    }
}
