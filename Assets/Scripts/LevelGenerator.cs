using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if(pixelColor.a == 0)
        {
            return;
        }
        foreach (var colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position =
                    new Vector3(x,0,z) * offset;
                Instantiate(colorMapping.prefab,
                    position, Quaternion.identity,
                    transform);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
