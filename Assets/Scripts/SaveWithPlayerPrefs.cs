using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Koppel dit Script aan een empty welke aan een knop genaamd Opslaan 1, 2, 3, etc hangt.

//Benodigdheden: 
//-LoadWithPlayerPrefs.cs (Laad script)
//-Detectnaam.cs (Classe om Opjectnaam (Opslaan 1, etc en Laden 1, etc te detecteren en te filteren op het nummer.

public class SaveWithPlayerPrefs : MonoBehaviour
{
    //Het element waar de gegevens van Positie Gegevens van uitgelezen moeten worden:
    public GameObject ParentPrefabFolder;
    public GameObject ParentPrefab;
    private GameObject ParentObject;

    //Naam:
    private string ObjectNaam;
    //Locatie:
    private string ParentPrefabString, ParentPrefabStringX, ParentPrefabStringY, ParentPrefabStringZ;
    //Rotatie:
    private string ParentPrefabStringRot, ParentPrefabStringRotX, ParentPrefabStringRotY, ParentPrefabStringRotZ;
    //Schaal:
    private string ParentPrefabStringScale, ParentPrefabStringScaleX, ParentPrefabStringScaleY, ParentPrefabStringScaleZ;
    //Seperator in het geheugen:
    private string Sep = ";";
    //Hoeveel objecten zijn er opgeslagen (ONr = ObjectNummer):
    public string ONr;
    //Text invoer veld voor opmerkingen:
    public InputField inputfield;

    //NaamClass - Detecteer de naam van de knop en laat alleen het nummer over blijven:
    private DetectNaam Dnaam = new DetectNaam();
    //De knopnaam wordt achterhaalt en Opslaan wordt weg gehaald:
    private string OpslaanNummer;
    //String voor oproepen opmerkingen:
    private string StringInput;


    //Instellen tekst:
    public int T1=10, T2=10, T3=450, T4=250;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SaveLoop();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Laden();
        }
    }

    public void SaveLoop()
    {
        OpslaanNummer = Dnaam.OpslaanObjectNaam();
        Debug.Log("Het nummer van de knop is :"+ OpslaanNummer);

        //Leeg het geheugen voor nieuwe gegevens weg worden geschreven:
        LeegGeheugen();

        SaveInputfield();
        
        //Loop welke de Parent doorloopt en de gegevens van alle objecten weg schrijft:
        for (int i = 0; i < ParentPrefabFolder.transform.childCount; i++)
        {
            ParentObject = ParentPrefabFolder.transform.GetChild(i).gameObject;

            //Bepaal het getal tbv de Playerprefs naam:
            ONr = i.ToString();

            //Bepaal de Gegevens:
            Naam();

            Locatie();
            Rotatie();
            Schaal();

            //Schrijf de gegevens weg:
            Opslaan();
        }
        PlayerPrefs.Save();
    }

    void LeegGeheugen()
    {
        int i = 0;
        while (PlayerPrefs.HasKey(OpslaanNummer + "Onaam" + i)) {

            //Verwijder het geheugen horende bij het knopnummer:
            PlayerPrefs.DeleteKey(OpslaanNummer + "Onaam" + i);
        } 
    }

    void SaveInputfield()
    {
        PlayerPrefs.SetString(OpslaanNummer + "Invoer",inputfield.text);
    }

    void Naam()
    {
        PlayerPrefs.SetString(OpslaanNummer + "Onaam" + ONr, ParentObject.name.ToString());

        //Debug.Log(OpslaanNummer + "Onaam" + ONr);
        //PlayerPrefs.SetString("Onaam" + ONr, ParentObject.name.ToString());
    }

    void Locatie()
    {
        //Locatie van object bepalen en converteren naar string:
        ParentPrefabStringX = ParentObject.transform.localPosition.x.ToString();
        ParentPrefabStringY = ParentObject.transform.localPosition.y.ToString();
        ParentPrefabStringZ = ParentObject.transform.localPosition.z.ToString();
    }

    void Rotatie()
    {
        //Rotatie van object bepalen en converteren naar string:
        ParentPrefabStringRotX = ParentObject.transform.localRotation.eulerAngles.x.ToString();
        ParentPrefabStringRotY = ParentObject.transform.localRotation.eulerAngles.y.ToString();
        ParentPrefabStringRotZ = ParentObject.transform.localRotation.eulerAngles.z.ToString();
    }

    void Schaal()
    {
        //Schaal van object bepalen en converteren naar string:
        ParentPrefabStringScaleX = ParentObject.transform.localScale.x.ToString();
        ParentPrefabStringScaleY = ParentObject.transform.localScale.y.ToString();
        ParentPrefabStringScaleZ = ParentObject.transform.localScale.z.ToString();
    }

    void Opslaan()
    {
        //Opslaan van Locatie in geheugen:
        PlayerPrefs.SetString(OpslaanNummer + "LocX" + ONr, ParentPrefabStringX);
        PlayerPrefs.SetString(OpslaanNummer + "LocY" + ONr, ParentPrefabStringY);
        PlayerPrefs.SetString(OpslaanNummer + "LocZ" + ONr, ParentPrefabStringZ);

        //Opslaan van Rotatie in geheugen:
        PlayerPrefs.SetString(OpslaanNummer + "RotX" + ONr, ParentPrefabStringRotX);
        PlayerPrefs.SetString(OpslaanNummer + "RotY" + ONr, ParentPrefabStringRotY);
        PlayerPrefs.SetString(OpslaanNummer + "RotZ" + ONr, ParentPrefabStringRotZ);

        //Opslaan van Schaal in geheugen:
        PlayerPrefs.SetString(OpslaanNummer + "SclX" + ONr, ParentPrefabStringScaleX);
        PlayerPrefs.SetString(OpslaanNummer + "SclY" + ONr, ParentPrefabStringScaleY);
        PlayerPrefs.SetString(OpslaanNummer + "SclZ" + ONr, ParentPrefabStringScaleZ);
    }


    void Laden()
    {
        //Voor het testen van een laad-functie, een debug met locatiegegevens na het intoetsen van de 2-toets:
        int i = 0;

        while (PlayerPrefs.HasKey(OpslaanNummer + "Onaam" + i))
        {
            Debug.Log("Laden data uit Playerprefs: " + i + " - " + PlayerPrefs.GetString(OpslaanNummer + "Onaam"+i)+" X: "+ PlayerPrefs.GetString(OpslaanNummer + "LocX" + i) + " Y: "+PlayerPrefs.GetString(OpslaanNummer + "LocY" + i) + " Z: "+ PlayerPrefs.GetString(OpslaanNummer + "LocZ" + i));

            i++;

            if (i > 10000)
            {
                break;
            }
        }
    }

    void OnGUI()
    {
        int i = 0;
        while (PlayerPrefs.HasKey(OpslaanNummer + "Onaam" + i))
        {

            GUI.Label(new Rect(T1, T2 * ((i * T2) / 5), T3, T4), "Naam: " + PlayerPrefs.GetString(OpslaanNummer + "Onaam" + i) + " X: " + PlayerPrefs.GetString(OpslaanNummer + "LocX" + i) + " Y: " + PlayerPrefs.GetString(OpslaanNummer + "LocY" + i) + " Z: " + PlayerPrefs.GetString(OpslaanNummer + "LocZ" + i));
            i++;

            if (i > 10000)
            {
                break;
            }
        }

    }
}