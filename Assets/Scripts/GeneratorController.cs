using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    public delegate void OnTouch(GeneratorController generator);
    public event OnTouch onTouch;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (onTouch != null)
            {
                onTouch(this);
            }
        }
    }
}
