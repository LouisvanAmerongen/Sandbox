using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDetectnaam : MonoBehaviour {

    private DetectNaam LadenOpslaanNaam = new DetectNaam();

    public void Opslaan()
    {
        string opslaannaam = LadenOpslaanNaam.OpslaanObjectNaam();
        Debug.Log("Het knopnummer van Opslaan is: " + opslaannaam);
    }

    public void Laden()
    {
        string ladennaam = LadenOpslaanNaam.LadenObjectNaam();
        Debug.Log("Het knopnummer van Laden is: " + ladennaam);
    }
}
