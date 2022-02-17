using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackPokerDB", menuName = "Base de Datos/Back Img", order = 2)]

public class ImgBackPokerDB : ScriptableObject
{
    [System.Serializable]
    public struct BackPokerImgs
    {
        public int id;
        public Sprite imgBack;
    }
    public BackPokerImgs[] backPokerImgs;
}
