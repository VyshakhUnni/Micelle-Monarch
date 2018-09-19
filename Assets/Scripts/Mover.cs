using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 7.5f;
    float minDistance = 4;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        Vector2 stoppingVelocity = new Vector2(0, 0);

        if (horizontalInput != 0)
            position.x += horizontalInput * speed * Time.deltaTime;
        if (verticalInput != 0)
            position.y += verticalInput * speed * Time.deltaTime;

        transform.position = position;

        if (gameObject.tag == "Follower")
        {
            Transform playerLocation = GameObject.FindWithTag("Player").transform;

            if (playerLocation.position.x + minDistance < position.x || playerLocation.position.y + minDistance < position.y
                || playerLocation.position.x - minDistance > position.x || playerLocation.position.y - minDistance > position.y )
            {
                Vector2 direction = new Vector2(playerLocation.position.x - position.x , playerLocation.position.y - position.y);
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction );
            }
            else if (gameObject.GetComponent<Rigidbody2D>().velocity != new Vector2(0,0))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = stoppingVelocity;    
            }
            
        }

        if (horizontalInput == 0 && verticalInput == 0)
            gameObject.GetComponent<Rigidbody2D>().velocity = stoppingVelocity;
    }
}
