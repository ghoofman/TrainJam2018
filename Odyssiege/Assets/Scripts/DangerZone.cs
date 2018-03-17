using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {
	public GameObject Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.D)) {
//			Die ();
//		}
	}

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision on dangerzone");
        Rigidbody2D rigidBody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody2D != null)
        {
            if (rigidBody2D.mass > 30.0f)
            {
                Die();
            }
        }
        else
        {
            Debug.Log("No rigidbody");
        }
    }

    private void Die()
	{
		Debug.Log("Die");
		var position = transform.position;
		var rotation = transform.rotation;
        Horse horse = gameObject.GetComponentInParent<Horse>();
		Destroy(horse.gameObject);
		Instantiate(Prefab, position, Quaternion.identity);
    }
}
