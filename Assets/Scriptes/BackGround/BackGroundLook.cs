using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLook : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector2 offset = Vector2.zero;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float PlayerX = Input.GetAxis("Horizontal");
        offset.x += PlayerX / speed  * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
