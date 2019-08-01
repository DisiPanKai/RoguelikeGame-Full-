using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public int Id;
    private Inventory _inv;


    void Start()
    {
        _inv = GameObject.Find("Slots Grid").GetComponent<Inventory>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (_inv.ItemList[_inv.CurrentBagNumber][Id].Id == -1) //если пустая клетка
        {
            droppedItem.SlotId = Id;
            droppedItem.BagId = _inv.CurrentBagNumber;
            _inv.ItemList[_inv.CurrentBagNumber][Id] = droppedItem.Item;
        }
        else //если есть итем в клете
        {
            int childId = 0;
            if (transform.GetChild(childId).name == "Slot Frame(Clone)")
                childId = 1;
            ItemData item = transform.GetChild(childId).GetComponent<ItemData>(); //текущий итем в клетке
            if (droppedItem.Item.Stackable && item.GetComponent<ItemData>().Item.Stackable) //если итемы стакаются
            {
                item.GetComponent<ItemData>().Item.Amount += droppedItem.Item.Amount;
                item.transform.GetChild(0).GetComponent<Text>().text = item.GetComponent<ItemData>().Item.Amount.ToString();
                Destroy(droppedItem.gameObject);
            }
            else //если не стакаются
            {
                //int tempDropedSlotId = droppedItem.SlotId;
                //int tempDropedBagId = droppedItem.BagId;
                item.GetComponent<ItemData>().SlotId = droppedItem.SlotId;
                item.GetComponent<ItemData>().BagId = droppedItem.BagId;
                Item tempCurrentItem = item.GetComponent<ItemData>().Item;
                if (droppedItem.BagId == _inv.CurrentBagNumber)
                {
                    item.transform.SetParent(_inv.SlotsList[droppedItem.SlotId].transform);
                    item.transform.position = _inv.SlotsList[droppedItem.SlotId].transform.position;
                }
                else
                {
                    Destroy(item.gameObject);
                }
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.position = transform.position;

                _inv.ItemList[droppedItem.BagId][droppedItem.SlotId] = tempCurrentItem;
                _inv.ItemList[_inv.CurrentBagNumber][Id] = droppedItem.Item;

                droppedItem.SlotId = Id;
                droppedItem.BagId = _inv.CurrentBagNumber;
            }
        }
        _inv.DestroySlotFrame();
        GameObject slotFrameCopy = Instantiate(_inv.SlotFrame);
        slotFrameCopy.transform.SetParent(transform, false);
        slotFrameCopy.transform.SetAsFirstSibling();
    }
}
