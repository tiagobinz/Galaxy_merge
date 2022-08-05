using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behaviour : MonoBehaviour
{
    [SerializeField] Shoot[] shootComponents = null;
    [SerializeField] GameObject normalProjectile = null;
    [SerializeField] GameObject bombsProjectile = null;
    [SerializeField] GameObject crazyProjectile = null;

    void Start()
    {
        StartCoroutine(Arrive());
    }

    void Shoot()
    {
        foreach(Shoot s in shootComponents)
        {
            s.SetProjectile(normalProjectile);
            s.SetInterval(0.2f);
        }
    }

    void Stop()
    {
        foreach (Shoot s in shootComponents)
        {
            s.SetProjectile(null);
        }
    }

    void BombsMode()
    {
        foreach (Shoot s in shootComponents)
        {
            s.SetProjectile(bombsProjectile);
            s.SetInterval(1f);
        }
    }

    void CrazyMode()
    {
        foreach (Shoot s in shootComponents)
        {
            s.SetProjectile(crazyProjectile);
            s.SetInterval(.1f);
        }
    }

    IEnumerator Arrive()
    {
        while(!GetComponent<GoToPosition>().IsAtPosition())
        {
            yield return null;
        }
        GetComponent<GoToPosition>().enabled = false;
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            Shoot();
            StartCoroutine(RightLeftMovement());
            yield return new WaitForSeconds(10);
            Stop();
            yield return new WaitForSeconds(3);
            BombsMode();
            yield return new WaitForSeconds(10);
            Stop();
            yield return new WaitForSeconds(5);
            CrazyMode();
            StartCoroutine(FollowPlayersShootOrigins());
            yield return new WaitForSeconds(7);
        }
    }

    IEnumerator RightLeftMovement()
    {
        float a = 0;
        while(a < Mathf.PI * 4)
        {
            a += Time.deltaTime * 2;
            transform.position = new Vector3(Mathf.Sin(a) * 30, transform.position.y, transform.position.z);
            transform.LookAt(new Vector3(0, 0, -14));
            yield return null;
        }

        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    IEnumerator FollowPlayersShootOrigins()
    {
        float t = 0;
        while (t < 10)
        {
            t += Time.deltaTime;
            foreach (Shoot s in shootComponents)
            {
                Player p = Player.GetClosestTo(s.transform.position);
                if (p)
                {
                    s.transform.LookAt(p.transform.position);
                }
            }
            yield return null;
        }

        foreach (Shoot s in shootComponents)
        {
            s.transform.localRotation = Quaternion.identity;
        }
    }
}
