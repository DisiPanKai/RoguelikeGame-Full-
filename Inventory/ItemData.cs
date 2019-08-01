using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item Item;
    //public int ItemAmount;
    public int BagId;
    public int SlotId;
    private Vector2 offset;
    private Inventory inv;
    //private GameObject[] bags;


    void Start()
    {
        inv = GameObject.Find("Slots Grid").GetComponent<Inventory>();
        //bags = GameObject.FindGameObjectsWithTag("Bags");

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Item.Id != null)
        {
            inv.Drag = true;
            offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
            transform.SetParent(transform.parent.parent);
            transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            inv.ItemList[BagId][SlotId] = new Item();
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (Item.Id != null)
        {
            transform.position = eventData.position - offset;
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        inv.Drag = false;
        if (BagId == inv.CurrentBagNumber)
        {
            transform.SetParent(inv.SlotsList[SlotId].transform);
            transform.position = inv.SlotsList[SlotId].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            inv.ItemList[BagId][SlotId] = Item;
        }
        else
        {
            inv.ItemList[BagId][SlotId] = Item;
            Destroy(eventData.pointerDrag.gameObject);
        }
        //inv.ItemList[BagId][SlotId] = Item;
    }


    public void ItemInfo()
    {
        GameObject.Find("Name of the Item").GetComponent<Text>().text = Item.Name;
        GameObject.Find("Type of the Item").GetComponent<Text>().text = Item.Type;
        //GameObject slotFrameCopy = Instantiate(inv.SlotFrame);
        //slotFrameCopy
        if (GameObject.Find("Slot Frame(Clone)") != null)
        {
            Destroy(GameObject.Find("Slot Frame(Clone)"));
        }
        GameObject slotFrameCopy = Instantiate(inv.SlotFrame);
        slotFrameCopy.transform.SetParent(transform.parent, false);
        slotFrameCopy.transform.SetAsFirstSibling();
    }
}
