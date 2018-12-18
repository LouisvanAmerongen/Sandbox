using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour {

    //Locatie van Map waar bestanden staan welke ge-instantiate (in het model gekopieerd) moeten worden:
    private string PrefabLocatie = "SKP/";
    //De naam van het object welke als Parent dient voor de instantiates:
    private string ParentObject = "Prefabs";
    //Het Gameobject welke als Parent dient voor de instantiates (ParentGameObject):
    private GameObject ParentGO;
    //Random object nummers:
    private int RandomX;
    private int RandomZ;
    private int RandomRotX;
    private int RandomRotY;
    private int RandomRotZ;
    private int RandomNr;

    //Hoeveel Random objecten moeten er geplaatst worden:
    public int Hoeveelheid;

    //Objectnamen:
    private string[] ObjectNamen = { "Euromast", "eiffe+tower", "PaleisOpDam", "skpfile (1)" };


    // Use this for initialization
    void Start () {
        //Vind de string-variabele en gabruik deze naam om het ParentGameObject te bepalen:
        ParentGO = GameObject.Find(ParentObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Rondomizer();
            //LeegParent();
            //PlaatsObjecten();

            //Hoeveelheid = Random.Range(0, 100);
            Debug.Log("Objecten zouden nu geplaatst moeten worden");   
        }
	}

    public void Rondomizer()
    {
        LeegParent();
        PlaatsObjecten();

        Hoeveelheid = Random.Range(0, 100);
    }

    void RandomNummers()
    {
        //Maak de X en Y Coordinaten random:
        Hoeveelheid = Random.Range(0, 100);
        RandomNr = Random.Range(0, 4);
        RandomX = Random.Range(-150, 150);
        RandomZ = Random.Range(-150, 150);
        RandomRotX = Random.Range(0, 360);
        RandomRotY = Random.Range(0, 360);
        RandomRotZ = Random.Range(0, 360);
    }

    void LeegParent()
        {
            foreach (Transform child in ParentGO.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    void PlaatsObjecten()
    {
        int ON = 0;

        while (ON < Hoeveelheid)
        {
            RandomNummers();

            GameObject Instance;
            string Onaam = ObjectNamen[RandomNr];
            Instance = Instantiate(Resources.Load(PrefabLocatie + Onaam) as GameObject, ParentGO.transform);
            Instance.name = Onaam;
            Instance.transform.localPosition = new Vector3(RandomX, 0, RandomZ);
            Instance.transform.localRotation = Quaternion.Euler(RandomRotX, RandomRotY, RandomRotZ);
            
            ON++;
        }
    }
}