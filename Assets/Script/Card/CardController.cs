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
    [Space]
    [Header("Configuración")]
    public int idFront;
    public int idBack;

    //TODO: Crear codigo para controlar la manipulacion de los sprites con un incremento automatico para mostrar X cantidad de cartas

    private void OnValidate()
    {
        imgFront.sprite = imgFrontPokerDB.frontPokerImgs[idFront].imgFront;
        imgBack.sprite = imgBackPokerDB.backPokerImgs[idBack].imgBack;
    }
}
