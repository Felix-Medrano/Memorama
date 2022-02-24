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

    //Lista para no mostrar cartas repetidas
    List<int> idCardSelect = new List<int>();

    //Lista para mostrar las cartas en Random
    List<int> listCardTemp = new List<int>();
    List<int> listCardShow = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        SetParCard();
    }

    public void SetParCard()
    {

        
        int numRep = 0;
        int id = Random.Range(0, (cardController.imgFrontPokerDB.frontPokerImgs.Length));
        idCardSelect.Add(id);

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

        for (int i = 0; i < listCardShow.Count; i++)
        {
            GameObject btnCard = Instantiate(botonCartaPrefab, panelBtns);
            btnCard.GetComponent<CardController>().SetImgFrontCard(listCardShow[i]);
        }

    }

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
