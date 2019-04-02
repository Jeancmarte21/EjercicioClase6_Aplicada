using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class MapManager : MonoBehaviour
{
    public GameObject Grama, Cruce, Horizontal, Vertical, Tree;
    public GameObject Player, Enemy1;
    public GameObject TreasureBlueClosed, TreasureBlueOpen, GemYellow;
    Dictionary<char, GameObject> cellsPrefabs;
    Dictionary<string, GameObject> charactersPrefabs;
    Dictionary<string, GameObject> itemsPrefabs;
    XmlDocument level1;
    GameObject _newCell;

    private void Awake()
    {
        cellsPrefabs = new Dictionary<char, GameObject>
        {
            { 'A', Tree },
            { 'E', Grama },
            { 'I', Cruce },
            { 'O', Vertical },
            { 'U', Horizontal }
        };
        charactersPrefabs = new Dictionary<string, GameObject>
        {
            { "Pira-Guchi", Player },
            { "Enemy1", Enemy1 }
        };
        itemsPrefabs = new Dictionary<string, GameObject>
        {
            { "TreasureBlueClosed", TreasureBlueClosed },
            { "TreasureBlueOpen", TreasureBlueOpen },
            { "GemYellow", GemYellow }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 8);

        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("level1").text);

        LoadMap();

        Player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        Camera.main.transform.SetParent(Player.transform);
    }

    private void LoadMap()
    {
        int i = 0, j;
        foreach(XmlNode filaActual in level1.SelectNodes("//Level/Map/Row"))
        {
            i--;
            j = 0;
            foreach(char celdaActual in filaActual.InnerText)
            {
                j++;
                Instantiate(cellsPrefabs[celdaActual], new Vector3(j, i), Quaternion.identity);
            }
        }

        foreach(XmlNode currentChar in level1.SelectNodes("//Level/Characters/Character"))
        {
            _newCell = Instantiate(charactersPrefabs[currentChar.Attributes["PrefabName"].Value], new Vector3(Single.Parse(currentChar.Attributes["PosX"].Value), Single.Parse(currentChar.Attributes["PosY"].Value)), Quaternion.identity);

            _newCell.name = currentChar.Attributes["UniqueObjectName"].Value;
        }

        foreach (XmlNode currentChar in level1.SelectNodes("//Level/Items/Item"))
        {
            _newCell = Instantiate(itemsPrefabs[currentChar.Attributes["PrefabName"].Value], new Vector3(Single.Parse(currentChar.Attributes["PosX"].Value), Single.Parse(currentChar.Attributes["PosY"].Value)), Quaternion.identity);

            _newCell.name = currentChar.Attributes["UniqueObjectName"].Value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
