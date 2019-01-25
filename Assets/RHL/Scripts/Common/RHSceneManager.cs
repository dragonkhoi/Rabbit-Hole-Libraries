using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RHSceneManager {

	//pass in the name of a named scene to load it in Single mode
	public void LoadScene(string sceneName) {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	//pass in the index of a scene to load it in Single mode
	public void LoadScene(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
	}
}
