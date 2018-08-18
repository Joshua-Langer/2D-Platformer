using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindMenu : MonoBehaviour {

    //private vars
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    bool waitingforKey;
    PauseMenu pauseMenu;
    
    
    // Use this for initialization
	void Start ()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        menuPanel = transform.Find("Panel");
        menuPanel.gameObject.SetActive(false);
        waitingforKey = false;
        for(int i = 0; i < menuPanel.childCount; i++)
        {
            if (menuPanel.GetChild(i).name == "leftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.left.ToString();
            if (menuPanel.GetChild(i).name == "rightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.right.ToString();
            if (menuPanel.GetChild(i).name == "jumpKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.jump.ToString();
            if (menuPanel.GetChild(i).name == "attackKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.attack.ToString();
            if (menuPanel.GetChild(i).name == "arcaneKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.setArcane.ToString();
            if (menuPanel.GetChild(i).name == "fireKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.setFire.ToString();
            if (menuPanel.GetChild(i).name == "iceKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.setIce.ToString();
            if (menuPanel.GetChild(i).name == "pauseKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = Grid.gameManagerProper.pause.ToString();
        }
	}

    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingforKey)
        {
            newKey = keyEvent.keyCode;
            waitingforKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingforKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    public IEnumerator WaitForKey()
    {
        while(!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingforKey = true;

        yield return WaitForKey();

        switch(keyName)
        {
            case "leftKey":
                Grid.gameManagerProper.left = newKey;
                buttonText.text = Grid.gameManagerProper.left.ToString();
                break;
            case "rightKey":
                Grid.gameManagerProper.right = newKey;
                buttonText.text = Grid.gameManagerProper.right.ToString();
                break;
            case "jumpKey":
                Grid.gameManagerProper.jump = newKey;
                buttonText.text = Grid.gameManagerProper.jump.ToString();
                break;
            case "attackKey":
                Grid.gameManagerProper.attack = newKey;
                buttonText.text = Grid.gameManagerProper.attack.ToString();
                break;
            case "arcaneKey":
                Grid.gameManagerProper.setArcane = newKey;
                buttonText.text = Grid.gameManagerProper.setArcane.ToString();
                break;
            case "fireKey":
                Grid.gameManagerProper.setFire = newKey;
                buttonText.text = Grid.gameManagerProper.setFire.ToString();
                break;
            case "iceKey":
                Grid.gameManagerProper.setIce = newKey;
                buttonText.text = Grid.gameManagerProper.setIce.ToString();
                break;
            case "pauseKey":
                Grid.gameManagerProper.pause = newKey;
                buttonText.text = Grid.gameManagerProper.pause.ToString();
                break;
        }
        yield return null;
    }
}
