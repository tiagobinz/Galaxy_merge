using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float lookAtTime = 2;

    float timer;
    Player p;


    void OnEnable()
    {
        timer = 0;
        p = Player.GetClosestTo(transform.position);
    }
    
    void Update()
    {
        if (p)
        {
            if (timer < lookAtTime || lookAtTime == 0)
            {
                timer += Time.deltaTime;
                Vector3 dirToPlayer = p.transform.position - transform.position;

                transform.rotation = Quaternion.LookRotation(dirToPlayer, Vector3.up);
            }
            else
            {
                enabled = false;
            }
        }
    }
}
