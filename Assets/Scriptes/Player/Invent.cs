using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invent : MonoBehaviour
{
    public GameObject[,] inventory = new GameObject[InventoryX, InventoryY];
    public Sprite[,] spriteInv = new Sprite[InventoryX, InventoryY];
    public int[,] countInv = new int[InventoryX, InventoryY];
    public GameObject InventoryAll, InventoryFast;
    public GameObject Temp_ID, TempSwapID1, TempSwapID2;
    public GameObject ID_18, ID_20, ID_21, ID_40, ID_41, ID_42;
    public Sprite Sprite_ID_18, Sprite_ID_20, Sprite_ID_21, Sprite_ID_40, Sprite_ID_41, Sprite_ID_42;
    public static int InventoryX = 9, InventoryY = 5;
    public GameObject EmptyGO;
    public Sprite EmptySprite, TempSwapSprite1, TempSwapSprite2;
    public Sprite Temp_Sprite;
    public int TempCount1, TempCount2, FirstClickX, SecondClickX, FirstClickY, SecondClickY;
    public bool IsFirstClick = true, IsBothEnter = false;

    private bool InventIsOpen = false;
    private bool Good = true;

    void Start()
    {
        for (int i = 0; i < InventoryY; i++)
        {
            for (int j = 0; j < InventoryX; j++)
            {
                inventory[j, i] = EmptyGO;
                spriteInv[j, i] = EmptySprite;
                countInv[j, i] = 0;
            }
        }
        TempSwapID1 = EmptyGO;
        TempSwapID2 = EmptyGO;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventIsOpen)
            {
                InventoryAll.SetActive(false);
                InventoryFast.SetActive(true);
                InventIsOpen = false;
            }
            else
            {
                InventoryAll.SetActive(true);
                InventoryFast.SetActive(false);
                InventIsOpen = true;
            }
        }
        if (Temp_ID != EmptyGO)
        {
            Check();
        }
        if (TempSwapID1 != EmptyGO && TempSwapID2 != EmptyGO)
        {
            inventory[FirstClickX, FirstClickY] = TempSwapID2;
            inventory[SecondClickX, SecondClickY] = TempSwapID1;
            TempSwapID1 = EmptyGO;
            TempSwapID2 = EmptyGO;
            spriteInv[FirstClickX, FirstClickY] = TempSwapSprite2;
            spriteInv[SecondClickX, SecondClickY] = TempSwapSprite1;
            TempSwapSprite1 = EmptySprite;
            TempSwapSprite2 = EmptySprite;
            countInv[FirstClickX, FirstClickY] = TempCount2;
            countInv[SecondClickX, SecondClickY] = TempCount1;
            TempCount1 = 0;
            TempCount2 = 0;
            FirstClickX = 0;
            FirstClickY = 0;
            SecondClickX = 0;
            SecondClickY = 0;
            IsBothEnter = false;
        }
        if (IsBothEnter == true)
        {
            if (TempSwapID1 != EmptyGO && TempSwapID2 == EmptyGO)
            {
                inventory[FirstClickX, FirstClickY] = EmptyGO;
                inventory[SecondClickX, SecondClickY] = TempSwapID1;
                TempSwapID1 = EmptyGO;
                spriteInv[FirstClickX, FirstClickY] = EmptySprite;
                spriteInv[SecondClickX, SecondClickY] = TempSwapSprite1;
                TempSwapSprite1 = EmptySprite;
                countInv[FirstClickX, FirstClickY] = 0;
                countInv[SecondClickX, SecondClickY] = TempCount1;
                TempCount1 = 0;
                FirstClickX = 0;
                FirstClickY = 0;
                SecondClickX = 0;
                SecondClickY = 0;
                IsBothEnter = false;
            }
        }
    }

    void Check()
    {
        Good = true;
        for (int i = 0; i < InventoryY; i++)
        {
            for (int j = 0; j < InventoryX; j++)
            {
                if (inventory[j, i] == EmptyGO || inventory[j, i] == Temp_ID)
                {
                    if (countInv[j, i] < 1000 && Good == true)
                    {
                        inventory[j, i] = Temp_ID;
                        spriteInv[j, i] = Temp_Sprite;
                        countInv[j, i] += 1;
                        Temp_ID = EmptyGO;
                        Temp_Sprite = EmptySprite;
                        Good = false;
                    }
                }
            }
        }
    }
}
