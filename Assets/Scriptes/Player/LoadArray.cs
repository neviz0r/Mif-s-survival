using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadArray : MonoBehaviour
{
    public GameObject ID0, ID1;
    public Transform Zero;
    private GameObject ID, IDL, IDR, IDD, IDU, IDTree;
    private float FloatPosMouseX, FloatPosMouseY, Healthh = 10;
    private int IntPosMouseX, IntPosMouseY;
    private int IntPosArrayTreeX, IntPosArrayTreeY;




    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Healthh <= 0)
        {
            var MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FloatPosMouseX = MousePos.x + 0.5f;
            FloatPosMouseY = MousePos.y + 0.5f;
            IntPosMouseX = (int)FloatPosMouseX;
            IntPosMouseY = (int)FloatPosMouseY;
            GetComponent<LoadTerrain>().arraygen[IntPosMouseX, IntPosMouseY] = ID0;
            Healthh = 10;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FloatPosMouseX = MousePos.x + 0.5f;
            FloatPosMouseY = MousePos.y + 0.5f;
            IntPosMouseX = (int)FloatPosMouseX;
            IntPosMouseY = (int)FloatPosMouseY;
            ID = GetComponent<LoadTerrain>().arraygen[IntPosMouseX, IntPosMouseY];
            IDL = GetComponent<LoadTerrain>().arraygen[IntPosMouseX - 1, IntPosMouseY];
            IDR = GetComponent<LoadTerrain>().arraygen[IntPosMouseX + 1, IntPosMouseY];
            IDU = GetComponent<LoadTerrain>().arraygen[IntPosMouseX, IntPosMouseY + 1];
            IDD = GetComponent<LoadTerrain>().arraygen[IntPosMouseX, IntPosMouseY - 1];
            if (ID == ID0)
            {
                if (IDL != ID0 || IDR != ID0 || IDU != ID0 || IDD != ID0)
                {
                    GetComponent<LoadTerrain>().arraygen[IntPosMouseX, IntPosMouseY] = ID1;
                    var block = Instantiate(ID1, Zero);
                    block.transform.position = new Vector3(IntPosMouseX, IntPosMouseY, 0);
                }
            }
        }
    }

    public void Health(float Health)
    {
        Healthh = Health;
    }
}
