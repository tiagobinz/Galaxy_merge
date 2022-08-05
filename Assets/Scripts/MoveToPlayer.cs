using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] float speed = 1;

    Player p;
    
    void OnEnable()
    {
        p = Player.GetClosestTo(transform.position);
    }
    
    void Update()
    {
        if (p)
        {
            Vector3 dirToPlayer = p.transform.position - transform.position;
            transform.Translate(dirToPlayer.normalized * Time.deltaTime * speed, Space.World);
        }
        else
        {
            p = Player.GetClosestTo(transform.position);
        }
    }
}
