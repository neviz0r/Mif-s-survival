using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenTerrain : MonoBehaviour
{
    public Transform Zero;
    public GameObject Player;
    public GameObject ID0, ID1, ID2, ID3, ID4, ID5;
    public GameObject ID6, ID7, ID8, ID9, ID10, ID11, ID12;
    public GameObject ID13, ID14, ID15, ID16, ID17, ID19;
    public GameObject ID30, ID31, ID32, ID33, ID34, ID35;
    public GameObject SentrePortal, PortalVert;
    public int HightMax = 280, HightMin = 270;
    private int Maxx = 2000, Maxy = 400;
    private int GroundHight, LastX = 0;
    private float PortalPosY;


    void Start()
    {    
        Generator();
        GetComponent<LoadTerrain>().enabled = true;
    }

    void Generator()
    {
        GroundHight = (HightMax + HightMin) / 2;
        SpawnHill();
        SpawnPlain();
        SpawnSee();
        SpawnWater();
        SpawnTrees();
        SpawnOres();
        SpawnCaves();
        SpawnTreasure();
        SpawnDungeons();
    }

    void SpawnY(int x)
    {
        for (int y = Maxy - 1; y >= 0; y--)
        {
            if (y > GroundHight)
            {
                GetComponent<LoadTerrain>().arraygen[x, y] = ID0;
            }
            if (y == GroundHight)
            {
                GetComponent<LoadTerrain>().arraygen[x, y] = ID1;
            }
            if (y < GroundHight && y >= GroundHight - 4)
            {
                GetComponent<LoadTerrain>().arraygen[x, y] = ID2;
            }
            if (y < GroundHight - 4)
            {
                GetComponent<LoadTerrain>().arraygen[x, y] = ID3;
            }
        }
    }

    void SpawnHill()
    {
        for (int x = LastX; x < LastX + 500; x++)
        {
            if (x <= LastX + 150 || x >= LastX + 350)
            {
                if (x % 5 == 0)
                {
                    GroundHight += Random.Range(-1, 2);
                }
                if (GroundHight > HightMax)
                {
                    GroundHight -= 2;
                }
                if (GroundHight < HightMin)
                {
                    GroundHight += 2;
                }
                SpawnY(x);
            }
            else
            {
                if (x > LastX + 150 && x < LastX + 170)
                {
                    GroundHight += Random.Range(2, 5);
                    SpawnY(x);
                }
                if (x >= LastX + 170 && x <= LastX + 330)
                {
                    if (x % 5 == 0)
                    {
                        GroundHight += Random.Range(-1, 2);
                    }
                    SpawnY(x);
                }
                if (x > LastX + 330 && x < LastX + 350)
                {
                    GroundHight += Random.Range(-2, -5);
                    SpawnY(x);
                }
            }
        }
        LastX += 500;
    }

    void SpawnPlain()
    {
        for (int x = LastX; x < LastX + 1000; x++)
        {
            if (x < LastX + 483 || x > LastX + 517)
            {
                if (x % 5 == 0)
                {
                    GroundHight += Random.Range(-1, 2);
                }
                if (GroundHight > HightMax)
                {
                    GroundHight -= 2;
                }
                if (GroundHight < HightMin)
                {
                    GroundHight += 2;
                }
                SpawnY(x);
            }
            else
            {
                PortalPosY = GroundHight + 1.5f;
                for (int y = Maxy - 1; y >= 0; y--)
                {
                    if (y >= GroundHight - 2)
                    {
                        GetComponent<LoadTerrain>().arraygen[x, y] = ID0;
                    }
                    if (y < GroundHight - 1 && y >= GroundHight - 4)
                    {
                        GetComponent<LoadTerrain>().arraygen[x, y] = ID2;
                    }
                    if (y < GroundHight - 4)
                    {
                        GetComponent<LoadTerrain>().arraygen[x, y] = ID3;
                    }
                }
            }
        }
        LastX += 1000;
    }

    void SpawnSee()
    {
        for (int x = LastX; x < LastX + 500; x++)
        {
            if (x < LastX + 100)
            {
                if (x % 5 == 0)
                {
                    GroundHight += Random.Range(-1, 2);
                }
                if (GroundHight > HightMax)
                {
                    GroundHight -= 2;
                }
                if (GroundHight < HightMin)
                {
                    GroundHight += 2;
                }
                SpawnY(x);
            }
            if (x >= LastX + 100 && x <= LastX + 150)
            {
                GroundHight += Random.Range(-2, 0);
                SpawnY(x);
            }
            if (x > LastX + 150 && x % 4 == 0)
            {
                GroundHight += Random.Range(-1, 1);
                SpawnY(x);
            }
        }
        LastX += 500;
    }

    void SpawnWater()
    {

    }

    void SpawnTrees()
    {
        GameObject Temp;
        int LastTreeX = 0;
        int RandPos = 0;
        int RandHight = 6;
        int RandRot = 0;
        for (int x = 10; x < LastX; x++)
        {
            if (20 < x && x < 149 || 1450 > x && x > 359)
            {
                if (x < 983 || x > 1017)
                {
                    for (int y = Maxy - 1; y >= 0; y--)
                    {
                        Temp = GetComponent<LoadTerrain>().arraygen[x, y];
                        if (Temp == ID1)
                        {
                            GroundHight = y;
                        }
                    }
                    if (x - LastTreeX > RandPos)
                    {
                        RandHight = Random.Range(6, 10);
                        RandRot = Random.Range(0, 2);
                        GetComponent<LoadTerrain>().arraygen[x, GroundHight + 1] = ID6;
                        for (int i = 0; i < RandHight - 5; i++)
                        {
                            GetComponent<LoadTerrain>().arraygen[x, GroundHight + 2 + i] = ID7;
                        }
                        if (RandRot == 0)
                        {
                            GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight - 3] = ID10;
                            GetComponent<LoadTerrain>().arraygen[x + 1, GroundHight + RandHight - 3] = ID11;
                            GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight - 2] = ID8;
                            GetComponent<LoadTerrain>().arraygen[x - 1, GroundHight + RandHight - 2] = ID9;
                        }
                        if (RandRot == 1)
                        {
                            GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight - 3] = ID8;
                            GetComponent<LoadTerrain>().arraygen[x - 1, GroundHight + RandHight - 3] = ID9;
                            GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight - 2] = ID10;
                            GetComponent<LoadTerrain>().arraygen[x + 1, GroundHight + RandHight - 2] = ID11;
                        }
                        GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight - 1] = ID12;
                        GetComponent<LoadTerrain>().arraygen[x + 1, GroundHight + RandHight - 1] = ID13;
                        GetComponent<LoadTerrain>().arraygen[x - 1, GroundHight + RandHight - 1] = ID14;
                        GetComponent<LoadTerrain>().arraygen[x - 1, GroundHight + RandHight] = ID15;
                        GetComponent<LoadTerrain>().arraygen[x, GroundHight + RandHight] = ID16;
                        GetComponent<LoadTerrain>().arraygen[x + 1, GroundHight + RandHight] = ID17;
                        RandPos = Random.Range(2, 5);
                        LastTreeX = x;
                    }
                }
            }
        }
    }

    void SpawnCaves()
    {

    }

    void SpawnTreasure()
    {

    }

    void SpawnOres()
    {
        GenOreDiamond();
        GenOreIron(); 
        GenOreIron();
        GenOreGold();
        GenOreCoal();
    }
    
    void GenOreDiamond()
    {
        int DiamondHightMax = 100, DiamondHightMin = 50;
    }

    void GenOreIron()
    {
        int IronHightMax = 280, IronHightMin = 100;
        for (int x = 20; x < Maxx - 20; x++)
        {
            int tempx = x;
            if (x % 3 == 0)
            {
                int y = Random.Range(IronHightMin, IronHightMax);
                int count = Random.Range(9, 13);
                for (int i = 0; i < count / 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        GetComponent<LoadTerrain>().arraygen[tempx, y - j] = ID31;
                    }
                    tempx++;
                }
            }
        }
    }

    void GenOreGold()
    {
        int GoldHightMax = 200, GoldHghtMin = 75;
    }

    void GenOreCoal()
    {
        int CoalHightMax = 290, CoalHightMin = 50;
    }

    void SpawnDungeons()
    {
        GenPortal();
        GenTempleRuins();
        GenRitualDiamond();
        GenGhostTower();
    }

    void GenPortal()
    {
        var portal = Instantiate(SentrePortal, Zero);
        portal.transform.position = new Vector3(1000, PortalPosY, 0);
        var portalvert = Instantiate(PortalVert, Zero);
        portalvert.transform.position = new Vector3(1000, PortalPosY + 6.5f, 0);
    }

    void GenTempleRuins()
    {

    }

    void GenRitualDiamond()
    {

    }

    void GenGhostTower()
    {

    }
}
