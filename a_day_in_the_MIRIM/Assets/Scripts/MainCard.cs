using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    [SerializeField] private ScenseController controller;
    [SerializeField] private GameObject Card_Back;

    public void OnMouseDown()
    {
        if(Card_Back.activeSelf && controller.canReveal)
        {
            Card_Back.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; //This gets the sprite renderer component and change the property of it's sprite!
    }
    
    public void Unrevel()
    {
        Card_Back.SetActive(true);
    }
    
    public void allBack()
    {

    }
}
