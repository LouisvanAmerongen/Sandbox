using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTest : MonoBehaviour {

    public Rect windowRect = new Rect(20, 20, 120, 50);
    public Rect buttonRect = new Rect(20, 20, 120, 50);
    public GUISkin Skin;

    void OnGUI()
    {
        // Register the window.

        GUI.skin = Skin;
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
    }

    // Make the contents of the window
    void DoMyWindow(int windowID)
    {
        // Make a very long rect that is 20 pixels tall.
        // This will make the window be resizable by the top
        // title bar - no matter how wide it gets.
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
        GUI.Button(buttonRect,"Button");
    }

}
