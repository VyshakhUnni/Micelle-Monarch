using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    float sides = 0f;
    public bool canDie = false;
    int attackingMicelle = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Follower") || col.gameObject.CompareTag("Player"))
            attackingMicelle++;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Follower") || col.gameObject.CompareTag("Player"))
            attackingMicelle--;
    }


    void Awake()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        sides = gameObject.GetComponent<PolygonCollider2D>().GetTotalPointCount();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }


    void Update()
    {
        if (attackingMicelle >= sides || canDie)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            canDie = true;
        }
        
    }

    void OnBecameInvisible()
    {
        if(canDie)
            Destroy(gameObject);
    }
}
