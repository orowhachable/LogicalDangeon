using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnScript : MonoBehaviour {
	public int itemnum;
	public GameObject spawnItem;

	managerScript managerPara;
	public GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Manager");
		managerPara = manager.GetComponent<managerScript>();
		if(managerPara.itemState[itemnum] == true){
			Instantiate(spawnItem, gameObject.transform.position, Quaternion.identity);
		}
	}
}
