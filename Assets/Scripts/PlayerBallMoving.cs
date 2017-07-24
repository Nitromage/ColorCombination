using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMoving : MonoBehaviour {

    public Vector3 Target;
    public float Speed;
    public bool startMoving;
    public Vector2 vector;
	// Use this for initialization
	void Start () {
        vector = Target - transform.position;
        vector.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
        if (startMoving)
        {
            transform.position += new Vector3(vector.x * Speed * Time.deltaTime, vector.y * Speed * Time.deltaTime, 0);
        }
    }
}
