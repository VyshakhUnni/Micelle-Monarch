using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailRotator : MonoBehaviour
{   
    void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
            Rotate(horizontalInput, verticalInput);
    }

    void Rotate(float horizontalValue, float verticalValue)
    {
        bool isRotating = true;
        Vector3 targetAngle = new Vector3(0, 0, 0);

        if (horizontalValue > 0)
            targetAngle = new Vector3(0, 0, 180);

        else if (horizontalValue < 0)
            targetAngle = new Vector3(0, 0, 0);

        if(verticalValue > 0)
            targetAngle = new Vector3(0, 0, 270);

        else if (verticalValue < 0)
            targetAngle = new Vector3(0, 0, 90);

        if(isRotating)
        {
            if (Vector3.Distance(transform.eulerAngles, targetAngle) > 0.5f)
            {
                if (Vector3.Distance(transform.eulerAngles, targetAngle) > 225)
                {
                    if (transform.rotation.z > 225 || transform.rotation.z < 315)
                        targetAngle = new Vector3(0, 0, 360);
                    else if (transform.rotation.z < 45 || transform.rotation.z > 315)
                        targetAngle = new Vector3(0, 0, -90);
                }
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetAngle, Time.deltaTime);
            }

            else
            {
                transform.eulerAngles = targetAngle;
                isRotating = false;
            }

        }
    }
}
