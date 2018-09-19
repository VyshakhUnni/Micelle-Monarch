using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailAttackBehaviour : MonoBehaviour
{
    GameObject target;
    //Vector2 direction = new Vector2(0,0);
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.contacts[0].point;

        if (collision.gameObject.tag == "Dirt")
        {
            if(Vector3.Distance(transform.eulerAngles,contactPoint) == 90)
            {
                Destroy(GetComponent<TailRotator>());
                GetComponentInParent<Rigidbody2D>().freezeRotation = true;
            }
            else
            {
                transform.Rotate(0, 0, 1);
            }
        }
    }
}
