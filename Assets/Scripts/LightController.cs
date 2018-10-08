using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () { 
	}

    public void LightsOn(GeneratorController generator)
    {
        generator.onTouch -= LightsOn;
        print("Yow");
        RenderSettings.ambientLight = Color.white;
    }
}
