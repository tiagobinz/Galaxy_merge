using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] Shoot[] projectileOrigins = null;
    [SerializeField] float autoExplodeAfterTime = 0;

    void Start()
    {
        Health h = GetComponent<Health>();
        if (h)
        {
            h.onDie += Explode;
        }
        if (autoExplodeAfterTime > 0)
        {
            StartCoroutine(AutoExplode());
        }
    }

    void Explode()
    {
        foreach(Shoot s in projectileOrigins)
        {
            s.ShootProjectile();
        }

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AutoExplode()
    {
        yield return new WaitForSeconds(autoExplodeAfterTime);
        Explode();
    }
}
