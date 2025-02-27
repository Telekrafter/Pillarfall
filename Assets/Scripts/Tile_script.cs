using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_script : MonoBehaviour
{
    public int Tile_index;

    public void Outline_On()
    {
        GetComponent<Renderer>().material.color = new Color(0f,1f,1f,0.0f);
    }
    public void Outline_Off()
    {
        GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.0f);
    }
}
