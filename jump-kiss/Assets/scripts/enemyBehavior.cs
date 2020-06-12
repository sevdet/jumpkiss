using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class enemyBehavior : MonoBehaviour {

	public Transform target; // what the enemy follows (so this gets set to player in the inspector
	public float speed; // speed of enemy
	public float speedUpgrade; // amount of speed increase every time enemy collects powerup
	public Animator animationController; // controlling animation for when enemy picks up a powerup
	//bool isCollecting = false; // using this to tell when the enemy has picked up a powerup so when this is true, it does the animation
	AudioSource audio; // sound effect for picking up powerup
	public ParticleSystem particles;


	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource>();
		particles = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {		

		// rotate enemy to face player
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);

		// translating enemy towards position of player
		if (Vector3.Distance(transform.position,target.position) > 0.4f){
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}


		if (Vector3.Distance (GameObject.FindWithTag ("player").transform.position, 
			transform.position) < 2.5f) {
			particles.Play ();
		} else {
			particles.Stop ();
		}
			
	}
		

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "powerup") {
			audio.Play(); // play powerup sound
			animationController.SetTrigger("pickup"); // play pickup animation once
			Destroy (coll.gameObject); // the collected powerup is no longer in the game
			speed += speedUpgrade; // speed increases when powerup collected
		} 
	}
		
}
