using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] GameObject Damage_VFX = null;
    [SerializeField] Team team = Team.Player;
    [SerializeField] bool destroy = true;

    void OnTriggerEnter(Collider c)
    {
        Health h = c.GetComponent<Health>();
        TeamComponent tC = c.GetComponent<TeamComponent>();
        DamageDealer dD = c.GetComponent<DamageDealer>();
        if (!dD)
        {
            if (tC)
            {
                if (tC.GetTeam() != team)
                {
                    if (h)
                    {
                        h.TakeDamage(damageAmount);
                        if (Damage_VFX)
                            Instantiate(Damage_VFX, transform.position, transform.rotation);
                    }
                    if (destroy)
                        Destroy(gameObject);
                }
            }
            else if (!c.GetComponent<ScoreBallMovement>())
            {
                if (destroy)
                    Destroy(gameObject);
            }
        }
    }
}
