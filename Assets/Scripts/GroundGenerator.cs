using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public GameObject floor;
	// Use this for initialization
	void Start () {
 
        for(float y = 1.97f; y > -3.55f; y -= .95f)
        {
            for(float x = -3.81f; x < 3.02f; x += 1.26f)
            {
                GameObject loadFloor = Instantiate(floor, new Vector3(x, y, 10f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
