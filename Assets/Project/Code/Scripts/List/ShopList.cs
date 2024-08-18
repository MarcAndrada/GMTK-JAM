
using System.Collections.Generic;
using UnityEngine;

public class ShopList : MonoBehaviour
{
    [SerializeField] private float addItemTime;

    private List<Item> items = new List<Item>();
    private float currentTime;

    int j = 0;

    private void Start()
    {
        currentTime = 0;

        items.Add(GenerateItem());
        Debug.Log(items[j].type);
        j++;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > addItemTime) 
        {
            items.Add(GenerateItem());
            Debug.Log(items[j].type);
            currentTime = 0;
            j++;
        }
    }

    private Item GenerateItem()
    {
        Item newItem = new Item();
        newItem.type = (Item.Type)Random.Range(0, (int)Item.Type.Last);
        for(int i = 0; i<items.Count; i++)
        {
            if(newItem.type == items[i].type)
            {
                Debug.Log("Se repite");
            }
        }
        return newItem;
    }
}
