using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTile : MonoBehaviour
{
    public GameObject[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        int spriteToUse = Random.Range(0, sprites.Length);
                GameObject sprite = Instantiate(sprites[spriteToUse], transform.position,Quaternion.identity);
                sprite.transform.parent = this.transform;
    }
}
