using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour {
	public float speed; //rate of paddle movement
	public float maxY;  //defines boundaries
	public float maxX;
	public float velocity;
	private Rigidbody rb;
	float lastXPos;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis ("Horizontal"); //Get keyboard input

//		Vector2 movement = new Vector2 (moveHorizontal,0.0f);//Store movement type in a variable
		
//		rb.AddForce (movement * speed);	// Combine movement and speed to force movement on rigid body

		float currentXPos = lastXPos;
		Vector3 pos = new Vector3(transform.position.x+(Time.deltaTime*moveHorizontal*speed),transform.position.y,transform.position.z); 
		transform.position = pos;     //Hold position when it reaches boundary
		velocity = (currentXPos - pos.x) / Time.deltaTime;
		lastXPos=pos.x;


		if (transform.position.x < -maxX || transform.position.x > maxX) {

			pos =new Vector3(transform.position.x-(Time.deltaTime*moveHorizontal*speed),transform.position.y,transform.position.z);
			transform.position = pos; 
			pos.x = Mathf.Clamp (pos.x, maxX, maxX); //Define boundaries

		}



}

}