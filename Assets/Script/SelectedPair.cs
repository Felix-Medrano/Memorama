using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedPair : MonoBehaviour
{

    GameObject firstCard = null;
    GameObject secondCard = null;

    int firstID = -1;
    int secondID = -1;

    int cantCardSelected = 0;


    /// <summary>
    /// Obtiene los valores Id y Objeto de la carta para realizar la comparacion de para y manupolar los objetos
    /// </summary>
    /// <param name="id">Id a comparar</param>
    /// <param name="card">Objeto a manipular</param>
    public void SetCard(int id, GameObject card)
    {
        if (firstID >= 0)
        {
            secondCard = card;
            secondID = id;
        }
        else
        {
            firstCard = card;
            firstID = id;
        }
        cantCardSelected++;
        if (cantCardSelected == 2)
        {
            if (firstID == secondID)
            {
                firstCard.transform.GetChild(0).gameObject.SetActive(false);
                firstCard.GetComponent<Button>().enabled = false;
                secondCard.transform.GetChild(0).gameObject.SetActive(false);
                secondCard.GetComponent<Button>().enabled = false;

            }
            ResetVar();

        }
    }


    /// <summary>
    /// Resetea los valores
    /// </summary>
    public void ResetVar()
    {
        firstCard = secondCard = null;
        firstID = secondID = -1;
        cantCardSelected = 0;
    }

}
