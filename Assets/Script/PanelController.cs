using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Dificultad
{
    Facil,
    Normal,
    Dificil
}

public class PanelController : MonoBehaviour
{
    [Header("Configuración General")]
    public Dificultad dificultad;

    int numCard;

    [Space]
    [Header("Configuración Botones")]
    public GameObject botonCartaPrefab;
    public Transform panelBtns;
    public CardController cardController;



    // Start is called before the first frame update
    void Start()
    {
        SetParCard();
    }

    public void SetParCard()
    {
        int numRep = 0;
        int id = Random.Range(0, (cardController.imgFrontPokerDB.frontPokerImgs.Length));

        if (dificultad == Dificultad.Facil)
        {
            numCard = 8;
        }
        if (dificultad == Dificultad.Normal)
        {
            numCard = 16;
        }
        if (dificultad == Dificultad.Dificil)
        {
            numCard = 24;
        }

        for (int i = 0; i < numCard; i++)
        {
            if (numRep == 2)
            {
                //TODO: Ciclo apra evitar cartas repetidas, pool de cartas ya seleccionadas(se manejara el 'id' como key)
                id = Random.Range(0, (cardController.imgFrontPokerDB.frontPokerImgs.Length));
                numRep = 0;
            }
            GameObject btnCard = Instantiate(botonCartaPrefab, panelBtns);
            btnCard.GetComponent<CardController>().SetImgFrontCard(id);
            
            numRep++;
        }
    }
}
