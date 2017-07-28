using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float EasySpeed;
    public float HardSpeed;
    public GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Difficulty == 0)
        {
            transform.position += new Vector3(0, -EasySpeed * Time.deltaTime, 0);
        }
        else transform.position += new Vector3(0, -HardSpeed * Time.deltaTime, 0);

    }
}
