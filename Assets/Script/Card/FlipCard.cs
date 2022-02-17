using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public Transform card;

    int rotY = 0;

    public void Flip()
    {

        //TODO: Hacer codigo para que rote gradualmente, no de golpe
        rotY = rotY == 0 ? 180 : 0;
        card.rotation = new Quaternion(0, rotY, 0, 0);
    }
    
}
