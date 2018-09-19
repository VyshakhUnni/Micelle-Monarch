using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joiner : MonoBehaviour
{
    public bool isFollowing = false;
    public bool targetFound = false;
    bool isExisting = true;

    [SerializeField]
    float thrust = 5f;

    public GameObject target;

    void Update()
    {
        if(targetFound && isExisting)
            attack(target);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFollowing == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameObject.AddComponent(typeof(Mover));
                Transform child = transform.GetChild(0);
                child.gameObject.AddComponent(typeof(TailRotator));
                isFollowing = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Dirt")
        {        
            targetFound = true;
            target = collider.gameObject;
            isFollowing = false;
        }
    }

    void OnBecameInvisible()
    {
        if (target != null)
            if (target.GetComponent<TargetBehaviour>().canDie && !isFollowing)
            {
                isExisting = false;
                Destroy(gameObject);
            }  
    }


    void attack(GameObject target)
    {
        Vector2 direction = new Vector2(0,0);
        if (target != null)
            direction = target.transform.position - gameObject.transform.position;              
        Destroy(gameObject.GetComponent<Mover>());
        Destroy(gameObject.GetComponentInChildren<TailRotator>());
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * thrust);
    }
}
