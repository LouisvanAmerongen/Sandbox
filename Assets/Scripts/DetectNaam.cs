using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]

public class DetectNaam 
{
    public string OpslaanObjectNaam()
    {
        //Achterhaal de naam van de knop
        string buttonname = EventSystem.current.currentSelectedGameObject.name;
        //Verander de naam van de knop zo dat alleen het nummer over blijft
        string Oprenummer = buttonname.Replace("Opslaan ", "");
        return Oprenummer;
    }

    public string LadenObjectNaam()
    {
        //Achterhaal de naam van de knop
        string buttonname = EventSystem.current.currentSelectedGameObject.name;
        //Verander de naam van de knop zo dat alleen het nummer over blijft
        string Lprenummer = buttonname.Replace("Laden ", "");
        return Lprenummer;
    }
}
