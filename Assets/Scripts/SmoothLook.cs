using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLook : MonoBehaviour
{
    [SerializeField]
    Transform Target;
	// Use this for initialization
	void Start ()
    { }	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(Target);	
	}
}
