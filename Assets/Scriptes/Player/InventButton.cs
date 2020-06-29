using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventButton : MonoBehaviour
{
    public int PosButtonX, PosButtonY;
    public int Count = 0;
    public Sprite ThisSprite, EmptySprite;
    public GameObject ThisGameObject, EmptyGO;
    public Text CountUI;

    private GameObject Player;
    private bool IsFirstClick;

    void Start()
    {
        Player = GameObject.Find("Player");
        EmptyGO = Player.GetComponent<Invent>().EmptyGO;
        EmptySprite = Player.GetComponent<Invent>().EmptySprite;
    }

    void Update()
    {
        ThisGameObject = Player.GetComponent<Invent>().inventory[PosButtonX - 1, PosButtonY - 1];
        ThisSprite = Player.GetComponent<Invent>().spriteInv[PosButtonX - 1, PosButtonY - 1];
        Count = Player.GetComponent<Invent>().countInv[PosButtonX - 1, PosButtonY - 1];
        gameObject.GetComponent<Image>().sprite = ThisSprite;
        if (Count > 0)
        {
            CountUI.text = " " + Count;
        }
    }

    public void OnClick()
    {
        Debug.Log(PosButtonX);
        Debug.Log(PosButtonY);
        IsFirstClick = Player.GetComponent<Invent>().IsFirstClick;
        if (IsFirstClick == true)
        {
            if (ThisGameObject != EmptyGO)
            {
                Player.GetComponent<Invent>().IsFirstClick = false;
                Player.GetComponent<Invent>().FirstClickX = PosButtonX - 1;
                Player.GetComponent<Invent>().FirstClickY = PosButtonY - 1;
                Player.GetComponent<Invent>().TempSwapID1 = ThisGameObject;
                ThisGameObject = EmptyGO;
                Player.GetComponent<Invent>().inventory[PosButtonX - 1, PosButtonY - 1] = ThisGameObject;
                Player.GetComponent<Invent>().TempSwapSprite1 = ThisSprite;
                ThisSprite = EmptySprite;
                Player.GetComponent<Invent>().spriteInv[PosButtonX - 1, PosButtonY - 1] = ThisSprite;
                Player.GetComponent<Invent>().TempCount1 = Count;
                Count = 0;
                Player.GetComponent<Invent>().countInv[PosButtonX - 1, PosButtonY - 1] = Count;
                CountUI.text = " ";
            }
        }
        else
        {
            Player.GetComponent<Invent>().IsFirstClick = true;
            Player.GetComponent<Invent>().SecondClickX = PosButtonX - 1;
            Player.GetComponent<Invent>().SecondClickY = PosButtonY - 1;
            Player.GetComponent<Invent>().TempSwapID2 = ThisGameObject;
            ThisGameObject = EmptyGO;
            Player.GetComponent<Invent>().inventory[PosButtonX - 1, PosButtonY - 1] = ThisGameObject;
            Player.GetComponent<Invent>().TempSwapSprite2 = ThisSprite;
            ThisSprite = EmptySprite;
            Player.GetComponent<Invent>().spriteInv[PosButtonX - 1, PosButtonY - 1] = ThisSprite;
            Player.GetComponent<Invent>().TempCount2 = Count;
            Count = 0;
            Player.GetComponent<Invent>().countInv[PosButtonX - 1, PosButtonY - 1] = Count;
            CountUI.text = " ";
            Player.GetComponent<Invent>().IsBothEnter = true;
        }
    }
}
 // CountUI.text = Count;