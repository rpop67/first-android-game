using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public Vector2 spawnAngleMinMax;

	Vector2 screenHalfSizeWorldUnits;

	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
		    float spawnAngle= Mathf.Lerp(spawnAngleMinMax.x,spawnAngleMinMax.y,Difficulty.GetDifficultyPercent());
			spawnAngle = Random.Range (-13, 13);
			nextSpawnTime = Time.time + secondsBetweenSpawns;



			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x+1, screenHalfSizeWorldUnits.x-1), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock=(GameObject)Instantiate (fallingBlockPrefab,spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
	}
}
