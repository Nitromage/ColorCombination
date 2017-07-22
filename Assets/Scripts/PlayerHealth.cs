using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Slider slider;
    public int StartingHealth = 10;
    public int CurrentHealth;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Text sliderText;

    // Use this for initialization
    void Start () {
        //CurrentHealth = StartingHealth;

	}

    private void Awake()
    {
        CurrentHealth = StartingHealth;
    }

    // Update is called once per frame
    void Update () {
        sliderText.text = "(" + CurrentHealth.ToString() + "/" + StartingHealth.ToString() + ")";
	}
}
