using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArthurChase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private ArthurState _currentState;

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case ArthurState.Chase:
                {

                    GetComponent<Image>().enabled = !GetComponent<Image>().enabled;

                    break;
                }
        }
    }

    public enum ArthurState
    {
        
        Chase,
        

    }
}
