using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_generator : MonoBehaviour
{
    public GameObject tile_prefab;
    public GameObject[] map;
    Quaternion quaternion_rotation;
    public int slay = 2;
    private Vector3 zero_tile_pos = new Vector3(0, 0, 0);

   void Start()
    {
        spawn_tiles();
    }
    public void spawn_tiles()
    {
        quaternion_rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        //формула для суммы тайлов и помещение их номерных пордяков в массив
        int tile_sum = 3 * slay * slay - 3 * slay + 1;
        map = new GameObject[tile_sum];
        int Tile_index = 0;

        //спавн центрального тайла и увеличение индекса тайла, помещение этого тайла в массив
        GameObject new_tile = Instantiate(tile_prefab, zero_tile_pos, quaternion_rotation);
        new_tile.GetComponent<Tile_script>().Tile_index += 1;
        map[0] = new_tile;

        //установка смещения тайла
        float tile_width = 0.875f;

        //перебор всех слоев
        for (int i = 1; i < slay; i += 1)
        {
            //позиция первого парта в слое
            Vector3 slays_pos = zero_tile_pos + new Vector3(tile_width * i, 0, 0);

            //перебор сторон тайла
            for (int side = 0; side < 6; side += 1)
            {
                Vector3 direction;

                //формулы размещения тайлов в зависимости от стороны
                switch(side)
                {
                    case 0: direction = new Vector3(tile_width / 2, 0, tile_width * Mathf.Sqrt(3) / 2); break;
                    case 1: direction = new Vector3(tile_width, 0, 0); break;
                    case 2: direction = new Vector3(tile_width / 2, 0, -tile_width * Mathf.Sqrt(3) / 2); break;
                    case 3: direction = new Vector3(-tile_width / 2, 0, -tile_width * Mathf.Sqrt(3) / 2); break;
                    case 4: direction = new Vector3(-tile_width, 0, 0); break;
                    case 5: direction = new Vector3(-tile_width / 2, 0, tile_width * Mathf.Sqrt(3) / 2); break;
                    default: direction = Vector3.zero; break;
                }

                //создание тайлов для сторон
                for (int j = 0; j < i; j += 1)
                {
                    //расчет позиции тайлов слоя в зависимости от номера  самого слоя
                    Vector3 tile_pos = slays_pos + direction * j; 
                    new_tile = Instantiate(tile_prefab, tile_pos, quaternion_rotation);
                    new_tile.GetComponent<Tile_script>().Tile_index += 1;
                    Debug.Log(Tile_index);
                    //map[Tile_index - 1] = new_tile;
                    Debug.Log(map);
                }
                slays_pos += direction * i;
            }
        }


    }
    
    
       
    
}