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


    [Header("Configuraci�n General")]
    public Dificultad dificultad;

    int numCard;

    [Space]
    [Header("Configuraci�n Botones")]
    public GameObject botonCartaPrefab;
    public Transform panelBtns;
    public CardController cardController;

    //Lista para no mostrar cartas repetidas
    List<int> idCardSelect = new List<int>();

    //Lista para mostrar las cartas en Random
    List<int> listCardTemp = new List<int>();
    List<int> listCardShow = new List<int>();

    //Lista para guardar las Cartas y poder trabajar con los objetos
    [HideInInspector]
    public List<GameObject> cards;
    
    void Start()
    {
        SetParCard();
    }

    public void SetParCard()
    {
        int numRep = 0;
        int id = Random.Range(0, (cardController.imgFrontPokerDB.frontPokerImgs.Length));
        idCardSelect.Add(id);

        //TODO: Cambiar la dificultad a UI
        if (dificultad == Dificultad.Facil) numCard = 8;
        if (dificultad == Dificultad.Normal) numCard = 16;
        if (dificultad == Dificultad.Dificil) numCard = 24;
        
        //Definimos las cartas a Mostrar
        for (int i = 0; i < numCard; i++)
        {
            if (numRep == 2)
            {
                bool check;
                do
                {
                    id = Random.Range(0, (cardController.imgFrontPokerDB.frontPokerImgs.Length));
                    check = CheckCardId(id, idCardSelect.Count, idCardSelect);
                } while (check == true);
                idCardSelect.Add(id);
                numRep = 0;
            }
            listCardTemp.Add(id);
            numRep++;
        }

        //Damos el Random a las cartas para mostrar
        for (int j = 0; j < numCard; j++)
        {
            int rnd = Random.Range(0, listCardTemp.Count);
            listCardShow.Add(listCardTemp[rnd]);
            listCardTemp.RemoveAt(rnd);
        }

        //Mostramos las cartas ya en orden aleatorio
        for (int i = 0; i < listCardShow.Count; i++)
        {
            GameObject btnCard = Instantiate(botonCartaPrefab, panelBtns);
            btnCard.GetComponent<CardController>().SetImgFrontCard(listCardShow[i]);
            btnCard.GetComponent<CardController>().cardID = listCardShow[i];
            cards.Add(btnCard);
        }
    }

    /// <summary>
    /// Hace un rrecorrido en la lista de designada para comprobar si ya eciste el id
    /// </summary>
    /// <param name="id">Id a comparar</param>
    /// <param name="n">cantidad de ciclos que va a tener(de 0 - n en la lista)</param>
    /// <param name="vs">Lista para buscar</param>
    /// <returns></returns>
    bool CheckCardId(int id, int n, List<int> vs)
    {
        bool check = false;
        for (int j = 0; j < n; j++)
        {
            if (vs[j] == id)
            {
                check = true;
                return check;
            }
        }   
        return check;
    }
}
