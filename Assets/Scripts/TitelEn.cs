using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitelEn : MonoBehaviour {

    public int T1 = 650, T2 = 10, T3 = 1000, T4 = 250;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
     
     GUI.Label(new Rect(T1, T2, T3, T4),"Opslaan en Laden tester in WebGL - Toets 1 = Opslaan - Toets 4 = Laden - Toets 7 = Randomizer ");

    }
}
