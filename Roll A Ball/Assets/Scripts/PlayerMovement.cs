using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 10f;
	public Text scoreText;
	public Text winText;
	private int score;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetScoreText ();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 roll = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.AddForce (roll * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			score += 1;
			SetScoreText ();
			if (score == 10) {
				winText.text = "YOU WIN!";
			}
		}
	}

	void SetScoreText() {
		scoreText.text = "SCORE: " + score.ToString ();
	}
}
