using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleShowImage();
        }
    }*/

    public void toggleShowImage()
    {
        GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
        
    }
}