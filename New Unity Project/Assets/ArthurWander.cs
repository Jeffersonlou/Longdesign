using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArthurWander : MonoBehaviour
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
            case ArthurState.Wander:
                {
                    
                    GetComponent<Image>().enabled = !GetComponent<Image>().enabled;

                    break;
                }
        }
    }

    public enum ArthurState
    {
        Wander,
    }
}
