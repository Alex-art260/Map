using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Map : MonoBehaviour
{
    public List<GameObject> maps = new List<GameObject>();

    public MapDataList  mapDataList = new MapDataList();

    public TextAsset textJSON;

    public Sprite[] sprite;

    private void Start()
    {
        mapDataList = JsonUtility.FromJson<MapDataList>(textJSON.text);
    
        foreach (var map in mapDataList.List)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                for (int j = 0; j < maps.Count; j++)
                {
                    maps[i].GetComponent<SpriteRenderer>().sprite = sprite[i];

                    if(sprite[i].name == map.Id)
                    {
                        map.Texture = sprite[i];

                        Vector2 pos = new Vector2(map.X, map.Y);
                        Vector2 scale = new Vector2(map.Width, map.Height);
                        maps[i].transform.localPosition = pos * 5.12f;
                        maps[i].transform.localScale = scale;
                        
                    } 
                }
            }
        }
    }

    [System.Serializable]
    public class MapData
    {
        public string Id;
        public Sprite Texture;
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }

    [System.Serializable]
    public class MapDataList
    {
        public List<MapData> List = new List<MapData>();

    } 
}



