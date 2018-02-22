using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;
	float visibleheight;

	void Start(){
		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
		visibleheight = -Camera.main.orthographicSize - transform.localScale.y;
	}

	void Update () {

		transform.Translate (Vector3.down * speed * Time.deltaTime);

		if (transform.position.y < visibleheight) {
			Destroy (gameObject);
		}
	}
}
