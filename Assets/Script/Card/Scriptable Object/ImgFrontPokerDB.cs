using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FrontPokerDB", menuName = "Base de Datos/Front Img", order = 1)]

public class ImgFrontPokerDB : ScriptableObject
{
    [System.Serializable]
    public struct FrontPokerImgs
    {
        public int id;
        public Sprite imgFront;
    }
    public FrontPokerImgs[] frontPokerImgs;
}
