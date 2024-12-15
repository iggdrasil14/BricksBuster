using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadControllerJSON : MonoBehaviour
{
    public Item item;

    [ContextMenu("Load")]
    public void LoadField()
    {
        item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
    }

    [ContextMenu("Save")]
    public void SaveField()
    {

        GameRules rules = FindObjectOfType<GameRules>();
        item.score = rules._playerScore;
        item.lifesPlayer = rules._playerLifes;
        item.namePlayer = SceneLoader.PlayerName;
        string json = JsonUtility.ToJson(item);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", json);
        PlayerPrefs.SetString("save", json);
    }

    [System.Serializable]
    public class Item
    {
        public string namePlayer;
        public int levelNumber;
        public int lifesPlayer;
        public int score;
    }
}