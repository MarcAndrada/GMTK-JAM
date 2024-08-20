using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.TerrainTools;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{
    [SerializeField] private float addItemTime;
    [SerializeField] private float distanceBetweenText;
    [SerializeField] private float distanceInitText;
    [SerializeField] private float distanceIncreaseShopList;

    [SerializeField] private GameObject newText;
    [SerializeField] private GameObject shopList;

    private Dictionary<Item.Type, int> items = new Dictionary<Item.Type, int>();

    private float currentTime;
    private float elapsedTime;
    private float startPosition;
    private float endPosition;

    private Vector2 currentPosition;

    private bool listFull = false;
    private int itemsObtained;
    private int itemsGenerated;
    

    private void Start()
    {
        currentTime = 0;
        itemsObtained = 0;
        itemsGenerated = 0;
        currentPosition = new Vector2(transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y - distanceInitText);
        for(int i = 0; i<3; i++)
        {
            GenerateItem();
        }
        startPosition = shopList.transform.localScale.y;
        endPosition = shopList.transform.localScale.y + distanceIncreaseShopList;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > addItemTime)
        {
            if (items.Count >= Enum.GetValues(typeof(Item.Type)).Length)
            {
                return;
            }
            else
            {
                GenerateItem();
            }
            currentTime = 0;
            elapsedTime = 0;
            startPosition = shopList.transform.localScale.y;
            endPosition = shopList.transform.localScale.y + distanceIncreaseShopList;
        }
        else if(!listFull && currentTime < addItemTime)
        {
            IncreasingList();
        }

    }

    private void GenerateItem()
    {
        Item.Type newItemType;
        bool uniqueItemFound = false;

        for (int attempts = 0; attempts < Enum.GetValues(typeof(Item.Type)).Length; attempts++)
        {
            newItemType = (Item.Type)UnityEngine.Random.Range(0, (int)Item.Type.Last);

            if (!items.ContainsKey(newItemType))
            {
                uniqueItemFound = true;
                items.Add(newItemType, 1);
                Item newItem = new Item { type = newItemType };
                GenerateText(newItem);
                itemsGenerated++;
                break;
            }
        }

        if (!uniqueItemFound)
        {
            listFull = true;
            Debug.Log("Se han generado todos los objetos");
        }

    }

    private void GenerateText(Item newItem)
    {
        GameObject itemText = Instantiate(newText);
        itemText.transform.SetParent(this.transform, true);
        itemText.transform.localPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
        itemText.transform.localScale = Vector3.one;

        itemText.GetComponent<TextMeshProUGUI>().text = newItem.type.ToString() + "...........x" + items[newItem.type];

        currentPosition.y = currentPosition.y - distanceBetweenText;
    }

    private void IncreasingList()
    {
        float coeficient;
        if(elapsedTime < addItemTime)
        {
            elapsedTime += Time.deltaTime;
            coeficient = elapsedTime / addItemTime;
        }
        else
        {
            coeficient = 1;
        }

        float endScale = ((1 - coeficient) * startPosition) + (coeficient * (endPosition));
        shopList.transform.localScale = new Vector3(shopList.transform.localScale.x, endScale, shopList.transform.localScale.z);

    }

    public void ItemObtained(Item.Type item)
    {
        int i = 1;
        foreach(var pair in items)
        {
            if(pair.Key == item && pair.Value != 0) 
            {
                items[item]--;
                transform.GetChild(i).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
                itemsObtained++;
                if(itemsObtained == itemsGenerated)
                {
                    Debug.Log("has ganado");
                }
                return;
            }
            i++;
        }
    }
}
