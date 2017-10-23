using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerScript : MonoBehaviour {
	public bool[] itemState;
	public int itemName;

	public GameObject player;
	public Vector3 playerPos;
	public Vector3 defaultPos;

	public float time;
	public float soundTime;

	void Awake () {

		player = GameObject.FindGameObjectWithTag ("Player");
		playerPos = player.transform.position;
		defaultPos = playerPos;
		DontDestroyOnLoad (this.gameObject);
	}
}
	