using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public TMP_Text msgTxt;
    private bool isDisplayingMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRestartGame(Component component, object data)
    {
        mainUI.SetActive(true);
    }
    public void OnPauseGame(Component component, object data)
    {

    }
    public void OnGameOver(Component component, object data)
    {

    }
    public void OnInteraction(Component component,object data)
    {
        if(component.gameObject.name=="Stone")
        {
            mainUI.SetActive(true);
        }
        if(component.gameObject.name=="BoxA")
        {
            if (!isDisplayingMessage)
                StartCoroutine(WriteTextWithDelay(" You have dropped in box A "));
        }
        if (component.gameObject.name == "BoxB")
        {
            if (!isDisplayingMessage)
                StartCoroutine(WriteTextWithDelay(" You have dropped in box B "));
        }
        if (component.gameObject.name == "BoxC")
        {
            if (!isDisplayingMessage)
                StartCoroutine(WriteTextWithDelay(" You have dropped in box C "));
        }
    }

    public void ShowMsg(string giveMsg)
    {
        if(!isDisplayingMessage)
            StartCoroutine(WriteTextWithDelay(giveMsg));
    }

    private IEnumerator WriteTextWithDelay(string msgToWrite)
    {
        // Set the flag to indicate that a message is currently being displayed.
        isDisplayingMessage = true;

        // Clear the text before writing the new message.
        msgTxt.text = "";

        foreach (char character in msgToWrite)
        {
            msgTxt.text += character;
            yield return new WaitForSeconds(0.05f);
        }

        // Wait for a moment before clearing the text.
        yield return new WaitForSeconds(1);

        // Clear the text again.
        msgTxt.text = "";

        // Reset the flag to allow displaying a new message.
        isDisplayingMessage = false;
    }

}
