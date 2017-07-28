using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public List<Button> buttonsPressed;
    public int vibrationDuration;
    public Button EasyButton;
    public Button HardButton;
    GameObject  gameController;
    public List<Button> MenuButtons;
	// Use this for initialization
	void Start () {
        buttonsPressed = new List<Button>();
        if (EasyButton != null)
        {
            EasyButton.gameObject.SetActive(false);
        }
        if (HardButton != null)
        {
            HardButton.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(Button button)
    {
        Vibration.Vibrate(vibrationDuration);
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Difficulty == 0)
        {
            if (!buttonsPressed.Contains(button))
            {
                if (buttonsPressed.Count == 0)
                {
                    buttonsPressed.Add(button);
                    Color color = button.GetComponent<Image>().color;
                    button.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = color;
                }
            }
            else
            {
                buttonsPressed.Remove(button);
                Color color = button.GetComponent<Image>().color;
                button.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = Color.white;
            }

        }
        else
        {
            if (!buttonsPressed.Contains(button))
            {
                //Handheld.Vibrate();
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
            else
            {
                buttonsPressed.Remove(button);
                Color color = button.GetComponent<Image>().color;
                color = new Color(color.r, color.g, color.b, 1);
                button.GetComponent<Image>().color = color;
                Color ballColor = GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color;
                if (buttonsPressed.Count == 0)
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                if (buttonsPressed.Count == 1)
                {
                    if (ballColor == new Color(0, 0, 0, 1) && color == new Color(1, 0, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
                    }
                    if (ballColor == new Color(0, 0, 0, 1) && color == new Color(0, 0, 1, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0.5f, 0, 1);
                    }
                    if (ballColor == new Color(0, 0, 0, 1) && color == new Color(1, 1, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                    }

                    if (ballColor == new Color(1, 0.5f, 0, 1) && color == new Color(1, 0, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0, 1);
                    }
                    if (ballColor == new Color(1, 0.5f, 0, 1) && color == new Color(1, 1, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
                    }

                    if (ballColor == new Color(1, 0, 1, 1) && color == new Color(0, 0, 1, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
                    }
                    if (ballColor == new Color(1, 0, 1, 1) && color == new Color(1, 0, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
                    }

                    if (ballColor == new Color(0, 1, 0, 1) && color == new Color(1, 1, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
                    }
                    if (ballColor == new Color(0, 1, 0, 1) && color == new Color(0, 0, 1, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 0, 1);
                    }
                }
                if (buttonsPressed.Count == 2)
                {
                    if (color == new Color(1, 0, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
                    }
                    if (color == new Color(1, 1, 0, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                    }
                    if (color == new Color(0, 0, 1, 1))
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchTest>().playerBall.GetComponent<MeshRenderer>().material.color = new Color(1, 0.5f, 0, 1);
                    }
                }
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene");
    }

    public void DifficultySettings()
    {
        foreach (Button button in MenuButtons)
        {
            button.gameObject.SetActive(false);
        }
        EasyButton.gameObject.SetActive(true);
        HardButton.gameObject.SetActive(true);

    }

    public void EasyGame()
    {
        //SetupGame();
        PlayerPrefs.SetInt("Difficulty", 0);
        PlayerPrefs.Save();
        //gameController.GetComponent<GameController>().Difficulty = 0;
        StartGame();
    }

    public void HardGame()
    {
        //SetupGame();
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.Save();
        //gameController.GetComponent<GameController>().Difficulty = 1;
        StartGame();
    }

    //void SetupGame()
    //{
    //    GameObject[] gameObjects = SceneManager.GetSceneByName("Scene").GetRootGameObjects();
    //    foreach (GameObject go in gameObjects)
    //    {
    //        if (go.tag == "GameController")
    //        {
    //            gameController = go;
    //        }
    //    }
    //}

    public void Option()
    {
        SceneManager.LoadScene("Options");
    }
    public void InOption()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
