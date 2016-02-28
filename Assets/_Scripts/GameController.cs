using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Transform spawnPoint;

	int indexEnemy = 0;
	public GameObject[] Wave1;
	public GameObject[] Wave2;
	public GameObject[] Wave3;
	bool wave1SetActive = true;
	bool wave2SetActive = false;
	bool wave3SetActive = false;

	public float wave1spawnTime;
	float waveTimer;

	GameObject[] enemyA;
	GameObject[] enemyB;

	void Start () {
		enemyA = GameObject.FindGameObjectsWithTag ("EnemyA");
		enemyB = GameObject.FindGameObjectsWithTag ("EnemyB");
	}
	
	// Update is called once per frame
	void Update () {
		SpawnMinionWave1 ();
	}


	public void SpawnMinionWave1(){
		if (wave1SetActive){
		    waveTimer += Time.deltaTime;

	     	if (waveTimer >= wave1spawnTime) {

			     Wave1 [indexEnemy].transform.position = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);	
			     Wave1 [indexEnemy].SetActive (true);

		      	indexEnemy++;
			    waveTimer = 0;

			    if (indexEnemy == Wave1.Length)
				    wave1SetActive = false;		
		    }
	    }
	}
}
