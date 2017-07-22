using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour {

	// Use this for initialization

    public float speed = 0.1F;
    public GameObject Player;
    public Vector3 spawnPosition;
    public GameObject Buttons;

    public List<Color> colors = new List<Color>();
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
            transform.position = new Vector3(target.x, target.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject go = GameObject.FindGameObjectWithTag("Buttons");
            List<Button> buttons = go.GetComponent<ButtonController>().buttonsPressed;

            if (buttons.Count == 2)
            {
                Quaternion spawnRotation = Quaternion.identity;
                GameObject playerBall = Instantiate(Player, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), spawnRotation);
                GameObject[] playerBalls = GameObject.FindGameObjectsWithTag("PlayerBall");
                playerBalls[playerBalls.Length - 1].GetComponent<PlayerBallMoving>().Target = target;

                for (int i = 0; i < buttons.Count; i++)
                {
                    colors.Add(buttons[i].image.color);
                }

                Color red = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
                Color green = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);
                Color blue = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 0.5f);


                if (colors.Contains(red) && colors.Contains(green))
                {
                    Debug.Log("yellow");
                    playerBall.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    playerBall.tag = "Color.yellow";
                }
                if (colors.Contains(green) && colors.Contains(blue))
                {
                    Debug.Log("cyan");
                    playerBall.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    playerBall.tag = "Color.cyan";
                }
                if (colors.Contains(red) && colors.Contains(blue))
                {
                    Debug.Log("magenta");
                    playerBall.GetComponent<MeshRenderer>().material.color = Color.magenta;
                    playerBall.tag = "Color.magenta";
                }
                for (int i = 0; i < buttons.Count; i++)
                {
                    Color color = go.GetComponent<ButtonController>().buttonsPressed[i].image.color;
                    go.GetComponent<ButtonController>().buttonsPressed[i].image.color = new Color(color.r, color.g, color.b, 1f);
                }
                buttons.Clear();
                colors.Clear();
                go.GetComponent<ButtonController>().buttonsPressed.Clear();
            }
        }
    }
}
