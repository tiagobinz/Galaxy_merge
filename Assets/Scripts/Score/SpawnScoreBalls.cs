using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScoreBalls : MonoBehaviour
{
    [SerializeField] int amount = 50;
    [SerializeField] GameObject scoreBall = null;
    
    void Start()
    {
        Health h = GetComponent<Health>();
        if (h)
        {
            h.onDie += SpawnBalls;
        }
    }

    void SpawnBalls()
    {
        for(int i = 0; i < amount; i++)
        {
            ScoreBallMovement s = Instantiate(scoreBall, transform.position, transform.rotation).GetComponent<ScoreBallMovement>();
            if (s)
            {
                Vector3 velocity = new Vector3
                (
                    Mathf.Sin(Mathf.Deg2Rad * i * 360 / amount),
                    0,
                    Mathf.Cos(Mathf.Deg2Rad * i * 360 / amount)
                ) * 500;               

                s.DoMovement(velocity);
            }
        }
    }
}
