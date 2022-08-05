using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Shoot[] shootingPoints = null;
    [SerializeField] KeyCode shootKey = KeyCode.None;
    
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            foreach(Shoot s in shootingPoints)
            {
                s.enabled = true;
            }
        }
        if (Input.GetKeyUp(shootKey))
        {
            foreach (Shoot s in shootingPoints)
            {
                s.enabled = false;
            }
        }
    }
}
