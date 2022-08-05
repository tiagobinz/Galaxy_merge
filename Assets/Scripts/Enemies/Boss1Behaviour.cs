using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Behaviour : MonoBehaviour
{
    [SerializeField] Shoot[] shootComponents = null;
    [SerializeField] GameObject shootAtPlayerProjectile = null;
    [SerializeField] GameObject crazyProjectile = null;

    void Start()
    {
        StartCoroutine("Loop");
    }

    void ShootAtPlayer()
    {
        foreach(Shoot s in shootComponents)
        {
            s.SetProjectile(shootAtPlayerProjectile);
            s.SetInterval(1);
        }
    }

    void Stop()
    {
        foreach (Shoot s in shootComponents)
        {
            s.SetProjectile(null);
        }
    }

    void GoCrazy()
    {
        foreach (Shoot s in shootComponents)
        {
            s.SetProjectile(crazyProjectile);
            s.SetInterval(0.25f);
        }
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            ShootAtPlayer();
            yield return new WaitForSeconds(10);
            Stop();
            yield return new WaitForSeconds(3);
            GoCrazy();
            yield return new WaitForSeconds(10);
        }
    }
}
