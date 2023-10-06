using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingUIManager : MonoBehaviour
{
    public Canvas forFloatingUIMsg;
    public Image floatingImage;
    private Image instanceImage;
    public Transform targetPos;
    public Vector3 offSet;
    private bool showNow;
    // Start is called before the first frame update
    void Start()
    {
        instanceImage = Instantiate(floatingImage, forFloatingUIMsg.transform).GetComponent<Image>();
        instanceImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(showNow)
            instanceImage.transform.position = Camera.main.WorldToScreenPoint(targetPos.position+offSet);
    }

    public void FloatingMsgState(bool showState)
    {
        showNow = showState;
        instanceImage.gameObject.SetActive(showNow);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FloatingMsgState(true);
            targetPos.gameObject.GetComponent<InteractableObject>().interactionRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FloatingMsgState(false);
            targetPos.gameObject.GetComponent<InteractableObject>().interactionRange = false;
        }
    }

}
   