using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSpawnController : MonoBehaviour {
    private GameObject[] spawnLocations;
    public GameObject generatorPrefab;
    public LightController lightController;
	// Use this for initialization
	void Start () {
        spawnLocations = GameObject.FindGameObjectsWithTag("GeneratorSpawn");
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, spawnLocations.Length);
        SpawnGeneratorPrefab(spawnLocations[index]);
    }

    void SpawnGeneratorPrefab(GameObject generatorSpawn)
    {
        GameObject generatorGameObject = Instantiate(generatorPrefab, generatorSpawn.transform.position, Quaternion.identity) as GameObject;
        print(generatorGameObject.name);
        GeneratorController generator = generatorGameObject.GetComponent<GeneratorController>();
        print("Hello!");
        generator.onTouch += GeneratorAnimation;
        generator.onTouch += lightController.LightsOn;
    }

    void GeneratorAnimation(GeneratorController generator)
    {
        generator.onTouch -= GeneratorAnimation;
        generator.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
    }
}
