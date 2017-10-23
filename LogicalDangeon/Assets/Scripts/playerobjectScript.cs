using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerobjectScript : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;

	private Rigidbody rb;
	private float movementInputValue;
	private float turnInputValue;

	void Awake(){
		rb = GetComponent<Rigidbody>();
		moveSpeed = 20.0f;
		turnSpeed = 30.0f;
	}
		
	void Start () {
		
	}

	void Update () {
		movementInputValue = Input.GetAxis("Vertical");
		turnInputValue = Input.GetAxis("Horizontal");
	}

	void FixedUpdate(){
		Move();
		Turn();
	}

	void Move(){
		Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
		transform.position += movement;
	}
		
	void Turn(){
		float turn = turnInputValue * turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
		transform.rotation *= turnRotation;
	}
}
