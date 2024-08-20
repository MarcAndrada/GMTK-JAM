using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{


    [SerializeField]
    private Item.Type itemType;

    private Vector3 initPosition;
    private Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartPos()
    {
        Destroy(gameObject);
        //transform.position = initPosition;
        //transform.rotation = initRotation;
    }

    public Item.Type GetItemType()
    {
        return itemType;
    }
}
