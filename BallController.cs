using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	private Rigidbody rb;
	public float velocity;
	Vector2 direction;
	public float MaxX;
	public float MaxY;
	float radius;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		direction = Vector2.one.normalized; //direction is (1,1) normalized
		radius = transform.localScale.x/2; //radius gets the half the width of the object

	}

	// Update is called once per frame
	void Update () {

		transform.Translate (direction * Time.deltaTime);
		if (transform.position.x-radius < -MaxX || transform.position.x+radius > MaxX) 
		{
			
			//direction.x = -direction.x;
			GetComponent<Rigidbody> ().velocity = -GetComponent<Rigidbody> ().velocity;

		}

		if (transform.position.y+radius > MaxY ) 
		{
			Debug.Log ("A");
			//direction.x = -direction.x;
			GetComponent<Rigidbody> ().velocity = -GetComponent<Rigidbody> ().velocity;

		}
	}



	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Paddle") {
			float vel = other.gameObject.GetComponent<PaddleControl> ().velocity;
			rb.AddForce (new Vector3 (-vel * 20, velocity, 0));
		}
	}
}
