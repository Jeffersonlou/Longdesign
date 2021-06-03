using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class information_Script : MonoBehaviour
{

    public Text _mytext;
    public GameObject nothing;

    void Update()
    {
        if(_mytext != null)
        {
            _mytext.text = "gameObject.name = " + nothing.name;
        }

    }
}
