using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour {

    public static XMLManager ins;

    void Awake()
    {
        ins = this;
    }

    

    public void SaveGame()
    {
        Debug.Log(Game.currentGame.ducatCount);
        XmlSerializer serializer = new XmlSerializer(typeof(Game));
        FileStream stream = new FileStream(Application.persistentDataPath +   // should be Application.persistentDataPath for an actual game
            "/saved_game.xml", FileMode.Create); // overwrites previous save
        serializer.Serialize(stream, Game.currentGame);
        stream.Close();
    }

    public void LoadGame()
    {

      /*      XmlSerializer deserializer = new XmlSerializer(typeof(AddressDirectory));
        TextReader reader = new StreamReader(@"D:\myXml.xml");
        object obj = deserializer.Deserialize(reader);
        AddressDirectory XmlData = (AddressDirectory)obj;
        reader.Close();*/


        XmlSerializer serializer = new XmlSerializer(typeof(Game));
        FileStream stream = new FileStream(Application.persistentDataPath +   // should be Application.persistentDataPath for an actual game
            "/saved_game.xml", FileMode.Open);
        object obj = serializer.Deserialize(stream);
        Game.currentGame = (Game)obj;
        stream.Close();

     /*   var serializer = new XmlSerializer(typeof(MonsterContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as MonsterContainer;
        }*/
    }
}

[System.Serializable]
public class Game
{
    public static Game currentGame;
    public int ducatCount = 0;


}

[System.Serializable]
public class GameDatabase
{
    public List<Game> list = new List<Game>();
}