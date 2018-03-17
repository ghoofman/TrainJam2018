using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour {
    public GameObject bloodPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        GameObject blood = Instantiate(bloodPrefab);
        blood.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.GetComponent<Tail>() != null)
        {
            Die();
            return;
        }

        Rigidbody2D rigidBody2D = collision2D.gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody2D != null)
        {
            if (rigidBody2D.mass > gameObject.GetComponent<Rigidbody2D>().mass)
            {
                Die();
            }
        }

    }
}
