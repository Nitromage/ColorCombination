﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            ScoreManager.score += 10;
        }
    }
}
