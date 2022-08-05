using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] float interval = 0.25f;
    [SerializeField] AudioClip SFX = null;

    float timer;

    void OnEnable()
    {
        ShootProjectile();
        timer = 0;
    }

    void Update()
    {
        if (interval > 0)
        {
            timer += Time.deltaTime;

            if (timer > interval)
            {
                ShootProjectile();
                timer = 0;
            }
        }
    }

    public void ShootProjectile()
    {
        if (projectile)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            if (SFX)
            {
                AudioSource.PlayClipAtPoint(SFX, transform.position);
            }
        }
    }

    public void SetProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }

    public void SetInterval(float newInterval)
    {
        interval = newInterval;
    }
}
