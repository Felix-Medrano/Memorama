using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{

    public Animator animator;
    bool backSide = true;

    public void Flip()
    {
        string animacion = "";

        if (backSide)
        {
            backSide = false;
            animacion = "FlipBackFront";
        }
        else
        {
            backSide = true;
            animacion = "FlipFrontBack";
        }

        animator.Play(animacion);

    }
    
}
