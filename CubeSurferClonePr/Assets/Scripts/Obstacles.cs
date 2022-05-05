using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<GameObject> _obstacles;
   
    [Range(0, 5)]
    public int height;

    private void OnValidate()
    {
        int count = 0;
        foreach (GameObject item in _obstacles)
        {
            if (count <= height)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
            count++;
        }
    }

    
}
