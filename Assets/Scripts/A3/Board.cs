using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    public int width;
    public int height;
    public GameObject tilePrefab;
    private BGTile[,] allTiles;

    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BGTile[width, height];
        SetUp();
    }

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                Instantiate(tilePrefab, tempPosition, Quaternion.identity);
            }
        }
    }
}
