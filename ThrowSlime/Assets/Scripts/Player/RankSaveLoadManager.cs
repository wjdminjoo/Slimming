using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class RankSaveLoadManager
{
    public static void SavePlayerRank(stopWatch rank){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/rank.sav", FileMode.Create);
    }
}


[SerializeField]
public class PlayerRankData{
    public List<int> rankdata;
    public PlayerRankData(stopWatch rank){
        rankdata = new List<int>();
    }
}