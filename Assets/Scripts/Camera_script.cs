using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Camera_script : MonoBehaviour
{
    private Tile_script previous_Tile;
    private Tile_script current_Tile;
   

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        float distanse_max = 100f;
        if (Physics.Raycast(ray, out hit, distanse_max))
        {
            Tile_script tile;
            tile = hit.collider.gameObject.GetComponent<Tile_script>();
            tile.Outline_On();
            current_Tile = tile;
        }
        else
        {
            current_Tile = null;
        }
        if (current_Tile != previous_Tile) 
        {
            if (previous_Tile != null)
            {
                previous_Tile.Outline_Off();
            }
            previous_Tile = current_Tile;
            
        }
    }
}
