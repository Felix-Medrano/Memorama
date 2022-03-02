using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;

public class SelectedPair : MonoBehaviour
{
    PanelController panelController;

    GameObject firstCard = null;
    GameObject secondCard = null;

    int firstID = -1;
    int secondID = -1;
    int cantCardSelected = 0;

    public List<int> cardOk = new List<int>();

    private void Start()
    {
        panelController = GetComponent<PanelController>();
    }

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
            DisableButtons(panelController.cards, false);
        }
        else
        {
            firstCard = card;
            firstCard.GetComponent<Button>().enabled = false;
            firstID = id;
        }
        cantCardSelected++;
        if (cantCardSelected == 2)
        {
            if (firstID == secondID)
                StartCoroutine(CardFlip(firstCard, secondCard));
            else
                StartCoroutine(ReturnFlip(firstCard, secondCard));
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

    /// <summary>
    /// Si las 2 cartas son iguals se desactiva el elemento button y el hijo que contiene lis sprites se deshabilita para no ser mostrado
    /// </summary>
    /// <param name="firstCard">Primera carta Clicada</param>
    /// <param name="secondCard">Segunda carta Clicada</param>
    /// <returns></returns>
    IEnumerator CardFlip(GameObject firstCard, GameObject secondCard)
    {
        yield return new WaitForSeconds(2);
        firstCard.transform.GetChild(0).gameObject.SetActive(false);
        secondCard.transform.GetChild(0).gameObject.SetActive(false);
        DisableButtons(panelController.cards, true);
        //firstCard.GetComponent<Button>().enabled = false;
        //secondCard.GetComponent<Button>().enabled = false;
        cardOk.Add(firstCard.GetComponent<CardController>().cardID);
        DelCardOk(panelController.cards, cardOk);

    }

    /// <summary>
    /// Si no son iguales las 2 cartas, regresan a estar cara abajo
    /// </summary>
    /// <param name="firstCard">Primera carta Clicada</param>
    /// <param name="secondCard">Segunda carta Clicada</param>
    /// <returns></returns>
    IEnumerator ReturnFlip(GameObject firstCard, GameObject secondCard)
    {
        yield return new WaitForSeconds(2);
        firstCard.GetComponent<FlipCard>().Flip();
        secondCard.GetComponent<FlipCard>().Flip();
        DisableButtons(panelController.cards, true);
        DelCardOk(panelController.cards, cardOk);

    }

    /// <summary>
    /// Recorre la lista de cartas para habilitarlas o deshabilitarlas, segun sea el caso
    /// </summary>
    /// <param name="cards">Lista de Cartas</param>
    /// <param name="state">Estado al que se van a cambiar las cartas</param>
    public void DisableButtons(List<GameObject> cards, bool state)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].GetComponent<Button>().enabled = state;
        }
    }

    public void DelCardOk(List<GameObject> cards, List<int> cardsOk)
    {
        print("a");
        for (int i = 0 ; i < cards.Count; i++)
        {
            print("b");
            for (int j = 0; j < cardsOk.Count; j++)
            {
                print("c"); 
                    print($"Card {i}: {cards[i].GetComponent<CardController>().cardID} - OkCard: {cardOk[j]}"); 
                if (cards[i].GetComponent<CardController>().cardID == cardsOk[j])
                {

                    cards[i].GetComponent<Button>().enabled = false;
                    print($"Card {i}: {cards[i].GetComponent<CardController>().cardID} - OkCard: {cardOk[j]}"); 
                }

            }
        }
    }
}
