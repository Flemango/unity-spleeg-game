using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class grid : MonoBehaviour
{
    public GameObject hex_prefab1, hex_prefab2;

    [SerializeField]
    int width, height;
    private float x_offset = 1.29f;
    private float y_offset = 1.125f;

    public void generate_grid(int w, int h, GameObject obj1, GameObject obj2, int pattern) //pattern 0-3
    {
        for(int x=0; x<w; x++)
                    for(int y=0; y<h; y++)
                    {
                        float x_pos = x * x_offset;
                        if (y%2 == 1) x_pos += x_offset/2;

                        switch(pattern)
                        {
                        case 1:
                            if (x%2 == 1) Instantiate(obj1, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                            else Instantiate(obj2, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                        break;
                        case 2:
                            if (y%2 == 1) Instantiate(obj1, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                            else Instantiate(obj2, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                        break;
                        case 3:
                            if (x%2 == 1 && y%2 == 1) Instantiate(obj1, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                            else Instantiate(obj2, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                        break;

                        default: //0
                            Instantiate(obj1, new Vector3(-x_pos, 0, -y*y_offset), Quaternion.identity, this.transform);
                            //obj1=PrefabUtility.InstantiatePrefab(obj1);
                        break;
                        }
                    }
    }

    void Start() //create
    {
        generate_grid(width, height, hex_prefab1, hex_prefab2, 2);
    }
}
