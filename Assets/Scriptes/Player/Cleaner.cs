using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public GameObject cube, player;
    private float FloatPosCubeX, FloatPosPlayerX;
    private float FloatPosCubeY, FloatPosPlayerY;
    private int IntPosCubeX, IntPosPlayerX;
    private int IntPosCubeY, IntPosPlayerY;
    private int IntPosPlayerMoreCubeX, IntPosPlayerMoreCubeY;
    private int IntPosCubesMoreCubeX, IntPosCubesMoreCubeY;

    void Start()
    {
        Vector3 PosCube = cube.transform.position;
        FloatPosCubeX = PosCube.x;
        FloatPosCubeY = PosCube.y;
        IntPosCubeX = (int)FloatPosCubeX;
        IntPosCubeY = (int)FloatPosCubeY;
        IntPosCubesMoreCubeX = IntPosCubeX / 10;
        IntPosCubesMoreCubeY = IntPosCubeY / 10;
    }

    void Update()
    {
        player = GameObject.Find("Player");
        Vector3 PosPlayer = player.transform.position;
        FloatPosPlayerX = PosPlayer.x;
        FloatPosPlayerY = PosPlayer.y;
        IntPosPlayerX = (int)FloatPosPlayerX;
        IntPosPlayerY = (int)FloatPosPlayerY;
        IntPosPlayerMoreCubeX = IntPosPlayerX / 10;
        IntPosPlayerMoreCubeY = IntPosPlayerY / 10;
        if (IntPosCubesMoreCubeX - IntPosPlayerMoreCubeX > 2 || IntPosCubesMoreCubeX - IntPosPlayerMoreCubeX < -2)
        {
            Destroy(gameObject);
        }
        if (IntPosCubesMoreCubeY - IntPosPlayerMoreCubeY > 2 || IntPosCubesMoreCubeY - IntPosPlayerMoreCubeY < -2)
        {
            Destroy(gameObject);
        }
    }
}
