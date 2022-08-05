using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeEventController : MonoBehaviour
{
    public delegate void OnEventsEndedDelegate();

    [SerializeField] int startAt = 0;
    [SerializeField] Event[] events = null;

    public OnEventsEndedDelegate onEventsEnded;
    
    void Start()
    {
        StartCoroutine(DoEvents());
    }

    IEnumerator DoEvents()
    {
        for(int i = startAt; i < events.Length; i++)
        {
            Event e = events[i];

            List<GameObject> eventObjects = DoEvent(e);
            if (e.endCondition == EventEndCondition.AllObjectsDestroyed)
            {
                bool allDestroyed = false;
                while(!allDestroyed)
                {
                    int nullObjects = 0;
                    foreach (GameObject g in eventObjects)
                    {
                        if (g == null)
                        {
                            nullObjects++;
                        }
                    }
                    allDestroyed = nullObjects == eventObjects.Count;
                    yield return new WaitForSeconds(1);
                }
            }
        }

        if (onEventsEnded != null)
        {
            onEventsEnded.Invoke();
        }
    }

    List<GameObject> DoEvent(Event e)
    {
        List<GameObject> returnedObjects = new List<GameObject>();

        foreach (ObjectSpawnInfo i in e.objectsToSpawn)
        {
            if (i.gameObject)
            {
                returnedObjects.Add
                (
                    Instantiate
                    (
                        i.gameObject,
                        new Vector3(i.xCoordinate, 0, i.zCoordinate),
                        Quaternion.Euler(0, i.rotation, 0)
                    )
                );
            }
        }

        return returnedObjects;
    }
}
