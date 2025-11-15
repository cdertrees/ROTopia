using System;
using System.Collections.Generic;
using UnityEngine;

public class TileSwap : MonoBehaviour
{
    public List<Material> colors;
    public List<SpriteRenderer> tiles;

    [SerializeField] private float timer;
    [SerializeField] private float waittime;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            foreach (SpriteRenderer tile in tiles)
            {
                int index;
                index = colors.IndexOf(tile.sharedMaterial);
                index++;
                //Debug.Log("Index for: " + tiles.IndexOf(tile) + " Is: " + index);
                //Debug.Log(colors.Count);
                if (index>=colors.Count)
                {
                    //Debug.Log("Index flipping");
                    index = 0;
                }
                tile.material = colors[index];
            }
            timer = waittime;
        }
    }
}
