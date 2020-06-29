using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandDeleter : MonoBehaviour
{
    public GameObject ThisTree, ID0, Drop;
    public int MaxQuantityDropDefault, MinQuantityDropDefault;
    public bool LeftPart;
    private GameObject NearTree, TTree, Scriptt;
    private float FloatPosThisTreeX, FloatPosThisTreeY;
    private int IntPosThisTreeX, IntPosThisTreeY;

    void Start()
    {
        Vector3 PosNowX = ThisTree.transform.position;
        FloatPosThisTreeX = PosNowX.x;
        IntPosThisTreeX = (int)FloatPosThisTreeX;
        Vector3 PosNowY = ThisTree.transform.position;
        FloatPosThisTreeY = PosNowY.y;
        IntPosThisTreeY = (int)FloatPosThisTreeY;
    }

    void Update()
    {
        Scriptt = GameObject.Find("Zero");
        if (LeftPart == true)
        {
            NearTree = Scriptt.GetComponent<LoadTerrain>().arraygen[IntPosThisTreeX + 1, IntPosThisTreeY];
        }
        if (LeftPart == false)
        {
            NearTree = Scriptt.GetComponent<LoadTerrain>().arraygen[IntPosThisTreeX - 1, IntPosThisTreeY];
        }
        if (NearTree == ID0)
        {
            int count = Random.Range(MinQuantityDropDefault, MaxQuantityDropDefault + 1);
            var position = transform.position;
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(Drop, new Vector2(position.x, position.y), Quaternion.identity);
                go.GetComponent<DropingItem>().Explode();
            }
            Scriptt.GetComponent<LoadTerrain>().arraygen[IntPosThisTreeX, IntPosThisTreeY] = ID0;
            Destroy(gameObject);
        }
    }
}