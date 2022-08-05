using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static List<Player> Players { get; private set; }
    
    void Awake()
    {
        if (Players == null)
        {
            Players = new List<Player>();
        }

        Players.Add(this);
    }

    void OnDestroy()
    {
        Players.Remove(this);
    }

    public static Player GetClosestTo(Vector3 position)
    {
        float bestDistance = float.MaxValue;
        Player bestplayer = null;

        if (Players != null)
        {
            foreach (Player p in Players)
            {
                float d = Vector3.Distance(p.transform.position, position);
                if (d < bestDistance)
                {
                    bestplayer = p;
                    bestDistance = d;
                }
            }
        }

        return bestplayer;
    }
}
