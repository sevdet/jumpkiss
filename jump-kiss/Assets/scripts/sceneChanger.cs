/*
this script needs to be changed eventually so that UnityEditor.SceneManagement isn't being used
to switch between scenes, need to find a different way so that it can build and run outside the editor 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P)) {
			if (Time.timeScale == 1){
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}

		if (Input.GetKey (KeyCode.G)) {
			if (SceneManager.GetActiveScene ().name == "maze1") {
				SceneManager.LoadScene ("maze2");
			} else if (SceneManager.GetActiveScene ().name == "maze2") {
				SceneManager.LoadScene ("maze3");
			} else if (SceneManager.GetActiveScene ().name == "maze3") {
				SceneManager.LoadScene ("titleScene");
			}
		}
			
		if (SceneManager.GetActiveScene().name != "titleScene") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				SceneManager.LoadScene ("titleScene");
			}
		} else {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("maze1");
			}
		}
	}
}
