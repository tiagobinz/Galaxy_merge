using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ScoreBallMovement : MonoBehaviour
{
    [SerializeField] bool giveScore = true;
    [SerializeField] bool giveHealth = false;

    Rigidbody rb = null;
    bool done = false;

    public void DoMovement(Vector3 velocity)
    {
        StartCoroutine(MovementRoutine(velocity));
    }

    void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();
        if (p)
        {
            StartCoroutine(Finish(p));
        }
    }

    IEnumerator MovementRoutine(Vector3 velocity)
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.AddForce(velocity);

            yield return new WaitForSeconds(0.5f);

            while (rb.velocity.magnitude > 5)
            {
                yield return null;
            }

            Player p = Player.GetClosestTo(transform.position);

            if (p)
            {
                float speed = rb.velocity.magnitude;
                while (!done)
                {
                    if (p)
                    {
                        rb.velocity = (p.transform.position - transform.position).normalized * speed;
                        speed += Time.deltaTime * 50;
                    }
                    else
                    {
                        p = Player.GetClosestTo(transform.position);
                        if (!p)
                        {
                            yield break;
                        }
                    }
                    yield return null;
                }

                rb.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator Finish(Player p)
    {
        done = true;
        GetComponent<MeshRenderer>().enabled = false;
        if (ScoreObject.Instance && giveScore)
        {
            ScoreObject.Instance.AddScore(1);
        }
        if (giveHealth)
        {
            p.GetComponent<Health>().AddHealth(1);
        }
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
