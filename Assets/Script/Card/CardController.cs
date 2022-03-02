using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    //[HideInInspector]
    public int cardID;

    [Header("Componentes Externos")]
    public GameObject gameController;

    [Header("Bases de Datos")]
    public ImgFrontPokerDB imgFrontPokerDB;
    public ImgBackPokerDB imgBackPokerDB;
    [Space]
    [Header("Sprites")]
    public SpriteRenderer imgFront;
    public SpriteRenderer imgBack;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
    }


    /// <summary>
    /// Selecciona la imagen a mostrar en la parte frontal de la carta
    /// </summary>
    /// <param name="idFront">Id de la DB paraidentificar la imagem</param>
    public void SetImgFrontCard(int idFront)
    {
        imgFront.sprite = imgFrontPokerDB.frontPokerImgs[idFront].imgFront;
    }

    /// <summary>
    /// Llama la funcion SetCard para comparar su id de carta y manupular el objeto de la carta seleccionada
    /// </summary>
    public void CallPair()
    {
        gameController.GetComponent<SelectedPair>().SetCard(cardID, this.gameObject);
    }

}
