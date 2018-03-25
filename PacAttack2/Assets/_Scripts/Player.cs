using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public AudioSource death;

	public Text DeathScreen;
	public Text DeathScreen2;
	public RawImage DeathImage;
	public Text Win1;
	public Text Win2;
	public Text Win3;

	private bool gameOver = false;

	public CharacterController controller;

	// Use this for initialization
	void Start () {
		DeathScreen.enabled = false;
		DeathScreen2.enabled = false;
		DeathImage.enabled = false;
		Win1.enabled = false;
		Win2.enabled = false;
		Win3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetKeyDown (KeyCode.R)) {				
				SceneManager.LoadScene ("Game");
			}
			
	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("PacMan")) {
			gameOver = true;
			StartCoroutine (Death ());
		} else if (other.tag.Equals ("ExitTrigger")) {
			StartCoroutine (Win ());
		}
	}

	IEnumerator Death(){
		Destroy (controller);
		death.Play ();
		yield return new WaitForSeconds (0.1f);
		DeathScreen.enabled = true;
		DeathScreen2.enabled = true;
		DeathImage.enabled = true;
	}

	IEnumerator Win(){
		Win1.enabled = true;
		yield return new WaitForSeconds (2f);
		Win1.enabled = false;
		Win2.enabled = true;
		yield return new WaitForSeconds (2f);
		Win2.enabled = false;
		Win3.enabled = true;
		yield return new WaitForSeconds (3f);
		Win3.enabled = false;

	}
}
