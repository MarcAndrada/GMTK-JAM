using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{

    [SerializeField]
    private Grab leftArmGrab;

    [SerializeField]
    private Grab rightArmGrab;

    [SerializeField] 
    private ShopList shopList;

    [SerializeField]
    private AudioClip itemObtained;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Item")
        {
            ItemBehaviour item = collision.gameObject.GetComponent<ItemBehaviour>();
            if (leftArmGrab.grabbedObject ==  item.gameObject)
            {
                leftArmGrab.ReleaseObject();
            }
            else
            {
                rightArmGrab.ReleaseObject();
            }
            ObjectObteined(item);
            item.RestartPos();

            AudioManager.instance.Play2dOneShotSound(itemObtained, "SFX", 1, 0.85f, 1.1f);
        }
    }

    private void ObjectObteined(ItemBehaviour item)
    {
        shopList.ItemObtained(item.GetItemType());
    }
}
