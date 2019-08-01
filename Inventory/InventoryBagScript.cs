using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryBagScript : MonoBehaviour, IDropHandler
{
    public int BagId;
    private GameObject _fullInv;
    private Inventory _inv;

    void Start()
    {
        _inv = GameObject.Find("Slots Grid").GetComponent<Inventory>();
        _fullInv = Resources.Load("Prefabs/Full Bag", typeof(GameObject)) as GameObject;
    }


    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        GetComponent<Image>().sprite = Resources.Load("Sprites/Bag", typeof(Sprite)) as Sprite; //стандартная картинка сумки
        for (int i = 0; i < _inv.ItemList[BagId].Count; i++) //помещение дропнутого итема в выделенную сумку
        {
            if (_inv.ItemList[BagId][i].Id == -1)
            {
                _inv.ItemList[droppedItem.BagId][droppedItem.SlotId] = new Item();
                _inv.ItemList[BagId][i] = droppedItem.Item;
                Destroy(droppedItem.gameObject);
                _inv.DestroySlotFrame();
                _inv.Drag = false;
                return;
            }
        }
        //если свободных слотов не оказалось, то выводим над сумкой сообщение о заполненной сумке
        GameObject fullInvCopy = Instantiate(_fullInv);
        fullInvCopy.transform.SetParent(transform, false);
        StartCoroutine(WaitThreeSeconds(fullInvCopy));
      
    }

    IEnumerator WaitThreeSeconds(GameObject obj) //уничтожение объекта со временем
    {
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }
}
