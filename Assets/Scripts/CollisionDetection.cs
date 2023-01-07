using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject unit;
    public bool collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == unit.transform.tag )
        {
            collided = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == unit.transform.tag )
        {
            collided = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
		if ( collision.gameObject.tag == unit.transform.tag )
		{
			collided = true;
		}
	}

    private void OnTriggerExit2D (Collider2D collision)
    {
		if ( collision.gameObject.tag == unit.transform.tag )
		{
			collided = false;
		}
	}
}
