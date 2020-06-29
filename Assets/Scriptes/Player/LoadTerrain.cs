using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadTerrain : MonoBehaviour
{
    public GameObject player;
    public Transform Zero;
    public static int MaxX = 2000, MaxY = 400;
    public GameObject[,] arraygen = new GameObject[MaxX, MaxY];
    private float FloatPosPlayerX, FloatPosPlayerY;
    private int IntPosPlayerX, IntPosPlayerY;
    private int IntPosPlayerMoreCubeX, IntPosPlayerMoreCubeY;
    private int PosLastCubeX, PosLastCubeY;


    void Start()
    {
        LoadStartTerrain();
    }

    void Update()
    {
        Vector3 PosNowX = player.transform.position;
        FloatPosPlayerX = PosNowX.x;
        IntPosPlayerX = (int)FloatPosPlayerX;
        Vector3 PosNowY = player.transform.position;
        FloatPosPlayerY = PosNowY.y;
        IntPosPlayerY = (int)FloatPosPlayerY;
        IntPosPlayerMoreCubeX = IntPosPlayerX / 10;
        IntPosPlayerMoreCubeY = IntPosPlayerY / 10;
        if (PosLastCubeX - IntPosPlayerMoreCubeX < 0) //Right
        {
            GenerateMoreCubesXRight();
            PosLastCubeX = IntPosPlayerMoreCubeX;
        }
        if (PosLastCubeX - IntPosPlayerMoreCubeX > 0) //Left
        {
            GenerateMoreCubesXLeft();
            PosLastCubeX = IntPosPlayerMoreCubeX;
        }
        if (PosLastCubeY - IntPosPlayerMoreCubeY < 0) //Up
        {
            GenerateMoreCubesYUP();
            PosLastCubeY = IntPosPlayerMoreCubeY;
        }
        if (PosLastCubeY - IntPosPlayerMoreCubeY > 0) //Down
        {
            GenerateMoreCubesYDown();
            PosLastCubeY = IntPosPlayerMoreCubeY;
        }
    }

    void GenerateMoreCubesXRight()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int x = (IntPosPlayerMoreCubeX + 2) * 10; x < (IntPosPlayerMoreCubeX + 3) * 10; x++)
            {
                for (int y = (IntPosPlayerMoreCubeY + 2 - i) * 10; y < (IntPosPlayerMoreCubeY + 3 - i) * 10; y++)
                {
                    var block = Instantiate(arraygen[x, y], Zero);
                    block.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }

    void GenerateMoreCubesXLeft()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int x = (IntPosPlayerMoreCubeX - 2) * 10; x < (IntPosPlayerMoreCubeX - 1) * 10; x++)
            {
                for (int y = (IntPosPlayerMoreCubeY + 2 - i) * 10; y < (IntPosPlayerMoreCubeY + 3 - i) * 10; y++)
                {
                    var block = Instantiate(arraygen[x, y], Zero);
                    block.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }

    void GenerateMoreCubesYUP()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int y = (IntPosPlayerMoreCubeY + 2) * 10; y < (IntPosPlayerMoreCubeY + 3) * 10; y++)
            {
                for (int x = (IntPosPlayerMoreCubeX + 2 - i) * 10; x < (IntPosPlayerMoreCubeX + 3 - i) * 10; x++)
                {
                    var block = Instantiate(arraygen[x, y], Zero);
                    block.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }

    void GenerateMoreCubesYDown()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int y = (IntPosPlayerMoreCubeY - 2) * 10; y < (IntPosPlayerMoreCubeY - 1) * 10; y++)
            {
                for (int x = (IntPosPlayerMoreCubeX + 2 - i) * 10; x < (IntPosPlayerMoreCubeX + 3 - i) * 10; x++)
                {
                    var block = Instantiate(arraygen[x, y], Zero);
                    block.transform.position = new Vector3(x, y, 0);
                }
            }
        }
    }

    void LoadStartTerrain()
    {
        Vector3 PosNowX = player.transform.position;
        FloatPosPlayerX = PosNowX.x;
        IntPosPlayerX = (int)FloatPosPlayerX;
        Vector3 PosNowY = player.transform.position;
        FloatPosPlayerY = PosNowY.y;
        IntPosPlayerY = (int)FloatPosPlayerY;
        IntPosPlayerMoreCubeX = IntPosPlayerX / 10;
        IntPosPlayerMoreCubeY = IntPosPlayerY / 10;
        PosLastCubeX = IntPosPlayerMoreCubeX;
        PosLastCubeY = IntPosPlayerMoreCubeY;
        for (int x = (IntPosPlayerMoreCubeX - 2) * 10; x < (IntPosPlayerMoreCubeX + 3) * 10; x++)
        {
            for (int y = (IntPosPlayerMoreCubeY - 2) * 10; y < (IntPosPlayerMoreCubeY + 3) * 10; y++)
            {
                var block = Instantiate(arraygen[x, y], Zero);
                block.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}
