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
            if (buttonsPressed.Count == 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = color;
                //Debug.Log("Ball color changed to: " + color.ToString());
            }
            if (buttonsPressed.Count == 2)
            {
                if (buttonsPressed[0].image.color == new Color(1, 0, 0, 0.5f) && button.image.color == new Color(1, 1, 0, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0.5f, 0, 1);
                    Debug.Log("Ball color changed to: " + new Color(1, 0.25f, 0, 1).ToString());
                }
                if (buttonsPressed[0].image.color == new Color(1, 0, 0, 0.5f) && button.image.color == new Color(0, 0, 1, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                    Debug.Log("Ball color changed to: " + new Color(1, 0, 1, 1).ToString());
                }
                if (buttonsPressed[0].image.color == new Color(1, 1, 0, 0.5f) && button.image.color == new Color(1, 0, 0, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0.5f, 0, 1);
                    Debug.Log("Ball color changed to: " + new Color(1, 0.25f, 0, 1).ToString());
                }
                if (buttonsPressed[0].image.color == new Color(1, 1, 0, 0.5f) && button.image.color == new Color(0, 0, 1, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
                    Debug.Log("Ball color changed to: " + new Color(0, 1, 0, 1).ToString());
                }
                if (buttonsPressed[0].image.color == new Color(0, 0, 1, 0.5f) && button.image.color == new Color(1, 1, 0, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
                    Debug.Log("Ball color changed to: " + new Color(0, 1, 0, 1).ToString());
                }
                if (buttonsPressed[0].image.color == new Color(0, 0, 1, 0.5f) && button.image.color == new Color(1, 0, 0, 0.5f))
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                    Debug.Log("Ball color changed to: " + new Color(1, 0, 1, 1).ToString());
                }
            }
            if (buttonsPressed.Count == 3)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
                Debug.Log("Ball color changed to: " + new Color(0, 0, 0, 1).ToString());
            }
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color += color;
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
