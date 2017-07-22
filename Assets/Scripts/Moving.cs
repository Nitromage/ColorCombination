using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float speed;
    public GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
	}
}
