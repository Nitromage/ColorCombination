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
    public GameObject playerBall;
    public int vibrationDuration;

    void Update()
    {
        if (playerBall == null)
        {
            Quaternion spawnRotation = Quaternion.identity;
            playerBall = Instantiate(Player, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), spawnRotation);
            playerBall.GetComponent<MeshRenderer>().material.color = Color.black;
            Debug.Log("Player Created");
        }

        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           // Vector3 target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).deltaPosition);
            transform.position = new Vector3(target.x, target.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0) && target.y >= playerBall.transform.position.y)
        {
            Vibration.Vibrate(vibrationDuration);
            playerBall.GetComponent<PlayerBallMoving>().startMoving = true;
            GameObject go = GameObject.FindGameObjectWithTag("Buttons");
            List<Button> buttons = go.GetComponent<ButtonController>().buttonsPressed;

            //Quaternion spawnRotation = Quaternion.identity;
            //GameObject playerBall = Instantiate(Player, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), spawnRotation);
            GameObject[] playerBalls = GameObject.FindGameObjectsWithTag("PlayerBall");
            playerBalls[playerBalls.Length - 1].GetComponent<PlayerBallMoving>().Target = target;
            playerBalls[playerBalls.Length - 1].GetComponent<PlayerBallMoving>().vector = playerBalls[playerBalls.Length - 1].GetComponent<PlayerBallMoving>().Target - playerBalls[playerBalls.Length - 1].transform.position;
            playerBalls[playerBalls.Length - 1].GetComponent<PlayerBallMoving>().vector.Normalize();

            Color ballColor = Color.black;
            if (buttons.Count > 0)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    ballColor += buttons[i].image.color;
                    
                }
               
            }
            ballColor.a = 1;
            playerBall.GetComponent<MeshRenderer>().material.color = ballColor;
            playerBall.tag = ballColor.ToString(); 
            playerBall.GetComponent<BallColor>().ballColor = playerBall.GetComponent<MeshRenderer>().material.color;
            //Debug.Log(ballColor.ToString());

            for (int i = 0; i < buttons.Count; i++)
            {
                Color color = go.GetComponent<ButtonController>().buttonsPressed[i].image.color;
                go.GetComponent<ButtonController>().buttonsPressed[i].image.color = new Color(color.r, color.g, color.b, 1f);
            }
            buttons.Clear();
            go.GetComponent<ButtonController>().buttonsPressed.Clear();
            playerBall = null;
        }
    }
}
