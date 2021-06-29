using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCon : MonoBehaviour
{
    bool showConsole;
    
    public void OnToggleDebug(Arthur value)
    {
        showConsole = !showConsole;
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        float y;
        GUI.Box(new Rect(0, 10, Screen.width, 30), "Arthur Text");
    }
}
