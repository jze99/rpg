using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    public List<Item> item = new List<Item>();
    public List<Drag> drag=new List<Drag>();
    public GameObject Inventory;
    void Start()
    {
        
    }

    void Update()
    {
        InventoryActive();
    }
    void InventoryActive()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(Inventory.activeSelf)
            {
                InventoryDisable();
            }
            else
            {
                InventoryEnable();
            }
        }
    }
    void InventoryDisable()
    {
        foreach(Drag drag in drag)
        {
            drag.RemoveCell();
        }
        Inventory.SetActive(false);
    }
    void InventoryEnable()
    {
        Inventory.SetActive(true);
        foreach(Drag drag in drag)
        {
            drag.RemoveCell();
        }
        for(int i=0;i<item.Count;i++)
        {
            drag[i].item=item[i];
            drag[i].image.sprite=Resources.Load<Sprite>(item[i].pathSprite);
            drag[i].owerItem="";
        }
    }
    public void RemuveItem(Drag _drag)
    {

    }
    public void UseItem(Drag _drag)
    {

    }
}
