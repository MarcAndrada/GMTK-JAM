using System;
using System.Collections.Generic;
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

    private Vector2 currentPosition;
    

    private void Start()
    {
        currentTime = 0;
        currentPosition = new Vector2(transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y - distanceInitText);
        GenerateItem();
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
                break;
            }
        }

        if (!uniqueItemFound)
        {
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
        shopList.transform.localScale = new Vector3(shopList.transform.localScale.x, shopList.transform.localScale.y + distanceIncreaseShopList, shopList.transform.localScale.z);
    }
}
