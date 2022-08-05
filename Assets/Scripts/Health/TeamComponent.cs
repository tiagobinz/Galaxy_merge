using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Team
{
    Player,
    Enemy,
    Neutral
}

public class TeamComponent : MonoBehaviour
{
    [SerializeField] Team team = Team.Player;

    public Team GetTeam()
    {
        return team;
    }
}
