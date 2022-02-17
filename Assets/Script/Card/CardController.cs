using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{

    [Header("Bases de Datos")]
    public ImgFrontPokerDB imgFrontPokerDB;
    public ImgBackPokerDB imgBackPokerDB;
    [Space]
    [Header("Sprites")]
    public SpriteRenderer imgFront;
    public SpriteRenderer imgBack;
    [Space]
    [Header("Configuración")]
    public int idFront;
    public int idBack;

    public void SetImgFrontCard()
    {
        int id = Random.Range(0, (imgFrontPokerDB.frontPokerImgs.Length));
        imgFront.sprite = imgFrontPokerDB.frontPokerImgs[id].imgFront;
    }

    //TODO: Crear codigo para controlar la manipulacion de los sprites con un incremento automatico para mostrar X cantidad de cartas

    private void OnValidate()
    {
        SetImgFrontCard();
        imgBack.sprite = imgBackPokerDB.backPokerImgs[idBack].imgBack;
    }
}
