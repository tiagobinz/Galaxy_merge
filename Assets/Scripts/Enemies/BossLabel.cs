using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLabel : MonoBehaviour
{
    void Start()
    {
        Health health = GetComponent<Health>();
        if (health)
        {
            health.onDie += OnDie;
        }
    }

    void OnDie()
    {
        FindObjectOfType<WinLoseController>().BossDefeated();
    }
}
