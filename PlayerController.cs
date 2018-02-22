using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {
	//public float speed=45;
	private bool FacingRight;

	float screenHalfWidthInWorldUnits;
	Rigidbody2D rb;
	//public AudioSource punchS;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		FacingRight = true;

		float halfPlayerWidth = transform.localScale.x*.5f ;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;

		//punchS = GetComponent<AudioSource> ();
	}


	private void Flip(float horival)
	{
		if (horival > 0 && !FacingRight || horival < 0 && FacingRight)
		{
			FacingRight = !FacingRight;
			Vector2 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;

		}
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = CrossPlatformInputManager.GetAxis ("Horizontal");

		//transform.Translate (Vector2.right * velocity * Time.deltaTime);

		if (transform.position.x < -screenHalfWidthInWorldUnits) {
			rb.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
			//transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
		}
		if (transform.position.x > screenHalfWidthInWorldUnits) {
			rb.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);

		}

		if (transform.position.x>= -screenHalfWidthInWorldUnits && transform.position.x <= screenHalfWidthInWorldUnits) {
			rb.velocity = new Vector2 (inputX * 40, 0);
		} else {
			rb.velocity = new Vector2 (0, 0);
		}

	



		Flip (inputX);
	}
	


	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag=="Falling Block"){
			FindObjectOfType<soundd> ().playSound ();//to start background splash audio
			//yield return new WaitForSeconds (0.4f);
			FindObjectOfType<bgsound>().muteSound();//to mute main background audio
			FindObjectOfType<GameOver> ().OnGameOver ();//set the gameover screen
			Destroy(gameObject);
		}
	}





}


