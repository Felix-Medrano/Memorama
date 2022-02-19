using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{

    Animator animator;
    bool backSide = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
