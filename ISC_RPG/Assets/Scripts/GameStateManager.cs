using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    string rutaXML;
    public static Game CurrentGame;

    private void Awake()
    {
        CurrentGame = new Game();
        rutaXML = Application.persistentDataPath + "/lastGameState.xml";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveState();
        else if (Input.GetKeyDown(KeyCode.F6))
            LoadState();
    }

    public void SaveState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

        using (FileStream fstream = new FileStream(rutaXML, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, CurrentGame);
        }
    }

    public void LoadState()
    {
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

        using (FileStream fstream = new FileStream(rutaXML, FileMode.Open))
        {
            CurrentGame = (Game)dcSerializer.ReadObject(fstream);
        }
    }
}
