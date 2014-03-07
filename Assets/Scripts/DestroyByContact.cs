﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start () 
	{
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
			Instantiate(explosion, transform.position, transform.rotation);
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.GameOver ();
		}
		if (other.tag == "Shooter")
		{
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
