using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent  restart;
    public GameObject playerRestPos;
    public Transform sequenceTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteraction(Component component, object data)
    {
        if (component.gameObject.name == "Stone")
        {
            sequenceTrans = playerRestPos.transform;
        }
    }
    public void OnRestartGame(Component component, object data)
    {
        playerRestPos.transform.position = sequenceTrans.position;
    }
}
