using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollider : MonoBehaviour {

    public Transform currWaypoint = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Waypoint"))
            currWaypoint = collision.gameObject.transform;
        else
            currWaypoint = null;
        print("Collision with " + collision.gameObject.name);
    }*/
}
