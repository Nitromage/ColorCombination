using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            other.GetComponent<PlayerRef>().player.GetComponent<PlayerHealth>().slider.value--;
            other.GetComponent<PlayerRef>().player.GetComponent<PlayerHealth>().CurrentHealth--;
            Destroy(gameObject);
        }
    }
}
