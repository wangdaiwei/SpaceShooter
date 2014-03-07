using UnityEngine;
using System.Collections;

public class EnemyBoltScript : MonoBehaviour {

	public GameObject playerExplosion;
	public Boundary boundary;

	private GameController gameController;
	
	void Update () {
		if (rigidbody.position.z < boundary.zMin) {
			Destroy(gameObject);
		}

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.GameOver ();
		}
	}
}
