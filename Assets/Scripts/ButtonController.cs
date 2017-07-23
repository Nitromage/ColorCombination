using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public List<Button> buttonsPressed;
    public int vibrationDuration;
	// Use this for initialization
	void Start () {
        buttonsPressed = new List<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(Button button)
    {
        if ( !buttonsPressed.Contains(button))
        {
            //Handheld.Vibrate();
            Vibration.Vibrate(vibrationDuration);
            buttonsPressed.Add(button);
            Color color = button.GetComponent<Image>().color;
            button.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color += color;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
