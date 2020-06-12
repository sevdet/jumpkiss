using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class winLoseConditions : MonoBehaviour {
	
	public Rigidbody2D rb;
	private int goalCount; // number of sparklies the player collects
	public int goalNum = 5; // number of sparklies necessary for winning
	AudioSource audio; // audio to play when sparkly is collected
	public float endSceneTime; // time to wait before the next scene starts playing 


	// Use this for initialization
	void Start () {

		goalCount = 0;
		audio = this.GetComponent<AudioSource> ();
		rb = this.GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {

		if (goalCount == goalNum) { // if goal number of sparklies is reached
			StartCoroutine(WaitAndLoadScene()); // wait and play win scene
		}

	}


	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "goal") { // if a sparkly is picked up
			audio.Play (); // play the player's pickup sound
			Destroy (coll.gameObject); // take picked up sparkly out of the game
			goalCount += 1; // update the player's goal count
		}

		if (coll.gameObject.tag == "enemy") { // if enemy is touched
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // gameover
		}
	}

	// doing this waiting so that the scenes don't change so suddenly
	IEnumerator WaitAndLoadScene()
	{
		yield return new WaitForSeconds (endSceneTime); // wait whatever time i set it to, then play the next scene
		if (SceneManager.GetActiveScene ().name == "maze1") {
			SceneManager.LoadScene ("maze2");
		} else if (SceneManager.GetActiveScene ().name == "maze2") {
			SceneManager.LoadScene ("maze3");
		} else if (SceneManager.GetActiveScene ().name == "maze3") {
			SceneManager.LoadScene ("titleScene");
		}
		
	}
	// i'm realizing now that i'm only doing this wait when the player wins, but not when they lose
	// so i need to implement that as well so the loseScene doesn't play so suddenly

}
