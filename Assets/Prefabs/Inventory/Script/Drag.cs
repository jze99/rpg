using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Drag : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public HeroInventory heroInventory;
    public Item item;
    public string owerItem;
    public int countItem;
    public Image image;
    public Sprite defaultSprite;
    public TextMeshProUGUI cout;
    public TextMeshProUGUI descriptioneCell;
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Left)
        {
            heroInventory.RemuveItem(this);
        }
      if(eventData.button==PointerEventData.InputButton.Right)
        {
            heroInventory.UseItem(this);
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public void RemoveCell()
    {
        item=null;
        image.sprite=null;
        descriptioneCell.text="";
        cout.text="";
        owerItem="";
    }
}
