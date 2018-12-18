using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWithPlayerPrefs : MonoBehaviour {

    //Locatie van Map waar bestanden staan welke ge-instantiate (in het model gekopieerd) moeten worden:
    private string PrefabLocatie = "SKP/";
    //De naam van het object welke als Parent dient voor de instantiates:
    private string ParentObject = "Prefabs";
    //Het Gameobject welke als Parent dient voor de instantiates (ParentGameObject):
    private GameObject ParentGO;
    //Variabele voor Gameobjects welke zijn ge-instantiate:
    private GameObject Instance;
    //Nummer om objecten uit database aan te duiden:
    private int ON;
    //Variabele voor Objectnamen:
    private string naam;
    //Achterhaal de naam van de knop:
    string buttonname;

    //String voor oproepen opmerkingen:
    private string StringInput;


    //NaamClass - Detecteer de naam van de knop en laat alleen het nummer over blijven:
    private DetectNaam Dnaam = new DetectNaam();
    //De knopnaam wordt achterhaalt en Laden wordt weg gehaald:
    private string LadenNummer;

    // Use this for initialization
    void Start ()
    {
        //Vind de string-variabele en gabruik deze naam om het ParentGameObject te bepalen:
        ParentGO = GameObject.Find(ParentObject);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            LeegParent();
            Laadgegevens();
        }
	}

    public void Laden()
    {
        //Detecteer het nummer van de knop:
        LadenNummer = Dnaam.LadenObjectNaam();

        LeegParent();
        Laadgegevens();
    }

    void Laadgegevens()
    {
        LoadInputfield();

        ON = 0;

        while (PlayerPrefs.HasKey(LadenNummer + "Onaam" + ON))
        {
            naam = PlayerPrefs.GetString(LadenNummer + "Onaam" + ON);
            Instance = Instantiate(Resources.Load(PrefabLocatie + naam) as GameObject, ParentGO.transform);

            Naam();
            Locatie();
            Rotatie();
            Schaal();

            ON++;
        }
    }

    public void LeegParent()
    {
        foreach (Transform child in ParentGO.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void LoadInputfield()
    {
        StringInput = PlayerPrefs.GetString(LadenNummer + "Invoer");

        Debug.Log("Laden nummer: "+LadenNummer+" Invoer is: " + StringInput);
    }

    void Naam()
    {
        Instance.name = naam;
    }

    void Locatie()
    {
        float X = float.Parse(PlayerPrefs.GetString(LadenNummer + "LocX" + ON));
        float Y = float.Parse(PlayerPrefs.GetString(LadenNummer + "LocY" + ON));
        float Z = float.Parse(PlayerPrefs.GetString(LadenNummer + "LocZ" + ON));

        Instance.transform.localPosition = new Vector3(X, Y, Z);
    }

    void Rotatie()
    {
        float rX = float.Parse(PlayerPrefs.GetString(LadenNummer + "RotX" + ON));
        float rY = float.Parse(PlayerPrefs.GetString(LadenNummer + "RotY" + ON));
        float rZ = float.Parse(PlayerPrefs.GetString(LadenNummer + "RotZ" + ON));

        Instance.transform.localRotation = Quaternion.Euler(rX,rY,rZ);
    }

    void Schaal()
    {
        float sX = float.Parse(PlayerPrefs.GetString(LadenNummer + "SclX" + ON));
        float sY = float.Parse(PlayerPrefs.GetString(LadenNummer + "SclY" + ON));
        float sZ = float.Parse(PlayerPrefs.GetString(LadenNummer + "SclZ" + ON));

        Instance.transform.localScale = new Vector3(sX, sY, sZ);
    }
}
