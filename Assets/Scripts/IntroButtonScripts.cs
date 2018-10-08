using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonScripts : MonoBehaviour {

	public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        print("Something Happened");
    }
}
