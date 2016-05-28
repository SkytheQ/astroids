using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	//FOR THE EXPLOSION ANiMATION!!!!
	public GameObject explosion;
	public GameObject playerExplosion;

	private GameController gameController;
	public int scoreValue;

	void Start(){
		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");
		if (gameControllerObj != null) {
			gameController = gameControllerObj.GetComponent<GameController> ();
		}
		if (gameControllerObj == null) {
			Debug.Log ("Cannot find the 'GameController' in the script");
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		//Dont destroy the boundary!
		if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy") || other.CompareTag("Asteroid") || other.CompareTag("VoidCol")) {
			return;	
		}
		if (explosion != null) {
			//FOR THE EXPLOSION ANiMATION!!!!
			Instantiate (explosion, transform.position, transform.rotation);
		}
		//Kill the PLAYER!
		if (other.CompareTag ("Player")) {
			//INSTANTIATE 2 ASTEROIDS
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
