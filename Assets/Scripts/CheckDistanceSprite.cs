using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class CheckDistanceSprite : MonoBehaviour
{
    [SerializeField] public Map map;
    [SerializeField] List<GameObject> newMap = new List<GameObject>();
    [SerializeField] private GameObject checkDistance;
    [SerializeField] private Text textSpriteName;
    [SerializeField] private GameObject infoWindow;

    public void SpriteNameOutput()
    {
        infoWindow.SetActive(true);

        for (int i = 0; i < map.maps.Count; i++)
        {
            newMap.Remove(map.maps[i]);
           
            newMap.Add(map.maps[i]);

            for (int j = 0; j < newMap.Count; j++)
            {
                newMap = newMap.OrderBy(x => Vector3.Distance(x.transform.position, checkDistance.transform.position)).ToList();
            }
        } 

        textSpriteName.text = " " + newMap[0].GetComponent<SpriteRenderer>().sprite.name;
    }

    public void CloseInfoButton()
    {
        infoWindow.SetActive(false);
    }
}
