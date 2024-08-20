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

    public IEnumerator RestartPos()
    {
        yield return new WaitForEndOfFrame();
        transform.position = initPosition;
        if (GetComponent<Rigidbody>() != null )
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        transform.rotation = initRotation;
    }

    public Item.Type GetItemType()
    {
        return itemType;
    }
}
