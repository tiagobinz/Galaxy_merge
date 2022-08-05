using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EventEndCondition
{
    Time,
    AllObjectsDestroyed
}

[System.Serializable]
public struct ObjectSpawnInfo
{
    public GameObject gameObject;
    public float xCoordinate;
    public float zCoordinate;
    public float rotation;
}

[CreateAssetMenu(fileName = "NewEvent", menuName = "Event")]
public class Event : ScriptableObject
{
    [SerializeField] public ObjectSpawnInfo[] objectsToSpawn;
    [SerializeField] public EventEndCondition endCondition;

    [SerializeField] public float waitTime;
}
