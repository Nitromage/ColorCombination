using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public List<Button> buttonsPressed;
	// Use this for initialization
	void Start () {
        buttonsPressed = new List<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(Button button)
    {
        if (buttonsPressed.Count != 2 && !buttonsPressed.Contains(button))
        {
            buttonsPressed.Add(button);
            Color color = button.GetComponent<Image>().color;
            button.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
        }
    }
}
