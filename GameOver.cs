using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
	bool gameOver;



	// Update is called once per frame
	void Update () {
		if (gameOver) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

				SceneManager.LoadScene (0);
			}

		}

	}

	public void OnGameOver() {
		gameOverScreen.SetActive (true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString ();
		gameOver = true;
	}
}
