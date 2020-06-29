using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingItem : MonoBehaviour
{
    public float ExplodeRangeX, ExplodeRangeY;
    private GameObject player;
    public GameObject BlockID, BlockID_Inv;
    public Sprite ThisSprite;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        player = GameObject.Find("Player");
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Invent>().Temp_ID = BlockID_Inv;
            player.GetComponent<Invent>().Temp_Sprite = ThisSprite;
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1 * ExplodeRangeX, ExplodeRangeX), Random.Range(0, ExplodeRangeY)));
    }
}
