using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [Header("Bases de Datos")]
    public ImgFrontPokerDB imgFrontPokerDB;
    public ImgBackPokerDB imgBackPokerDB;
    [Space]
    [Header("Sprites")]
    public SpriteRenderer imgFront;
    public SpriteRenderer imgBack;

    public void SetImgFrontCard(int idFront)
    {
        imgFront.sprite = imgFrontPokerDB.frontPokerImgs[idFront].imgFront;
    }

}
