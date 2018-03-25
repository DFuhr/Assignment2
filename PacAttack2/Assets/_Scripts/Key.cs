using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {


	public GameController gameController;
	public AudioSource Ding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down * 1f);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag.Equals ("Player")) {
			StartCoroutine(Collect());

		}
	}
	IEnumerator Collect (){
		Ding.Play ();
		transform.Translate (Vector3.down * 9999f);
		gameController.CollectKey();
		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}
}
