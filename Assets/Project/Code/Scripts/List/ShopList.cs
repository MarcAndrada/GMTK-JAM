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
            GenerateItem();
            currentTime = 0;
        }
    }

    private void GenerateItem()
    {
        Item newItem = Instantiate(new Item());
        newItem.type = (Item.Type)Random.Range(0, (int)Item.Type.Last);
        Debug.Log(newItem.type);

        int i = 0;

        foreach (var pair in items)
        {
            if (newItem.type == pair.Key)
            {
                items[newItem.type] += 1;
                transform.GetChild(i + 1).GetComponent<TextMeshProUGUI>().text = newItem.type.ToString() + "...........x" + items[newItem.type];
                return;
            }
            i++;
        }
        items.Add(newItem.type, 1);
        GenerateText(newItem);
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
