using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject slotsGrid;
    public GameObject Slot;
    public GameObject Item;
    public GameObject SlotFrame;

    public bool Drag = false;

    int slotAmount;
    int bagAmount;

    public int CurrentBagNumber;

    public List<GameObject> SlotsList = new List<GameObject>();

    public List<List<Item>> ItemList = new List<List<Item>>();


    void Start()
    {
        slotsGrid = this.gameObject;
        CurrentBagNumber = 0;
        bagAmount = 4;
        slotAmount = 16;
        CreateItemList();
        CreateSlotGrid();
        AddItem(0, 0, 0);
        AddItem(0, 1, 0);
        AddItem(0, 1, 0);
        AddItem(0, 2, 1);
        AddItem(1, 0, 2);
        AddItem(1, 1, 2);
        AddItem(1, 2, 2);
        AddItem(1, 3, 2);
        AddItem(1, 4, 2);
        AddItem(1, 5, 2);
        AddItem(1, 6, 2);
        AddItem(1, 7, 2);
        AddItem(1, 8, 2);
        AddItem(1, 9, 2);
        AddItem(1, 10, 2);
        AddItem(1, 11, 2);
        AddItem(1, 12, 2);
        AddItem(1, 13, 2);
        AddItem(1, 14, 2);
        AddItem(1, 15, 2);

    }


    void CreateItemList()
    {
        for (int i = 0; i < bagAmount; i++)
        {
            ItemList.Add(new List<Item>());
            for (int j = 0; j < slotAmount; j++)
            {
                ItemList[i].Add(new Item());
            }
        }

    }


    void CreateSlotGrid()
    {
        for (int i = 0; i < slotAmount; i++)
        {
            GameObject slotObj = Instantiate(Slot);
            slotObj.name = "Slot " + (i + 1);
            SlotsList.Add(slotObj);
            SlotsList[i].GetComponent<Slot>().Id = i;
            slotObj.transform.SetParent(slotsGrid.transform, false);

            //if (i == 0 || i == 2 || i == 5)
            //{
            //    Items.Add(new Item());
            //    GameObject itemObj = Instantiate(Item);
            //    itemObj.GetComponent<ItemData>().SlotId = i;
            //    itemObj.transform.SetParent(slotObj.transform, false);
            //}
        }
    }


    void RemoveItemsFromGrid()
    {
        GameObject[] itemsToDelete = GameObject.FindGameObjectsWithTag("Items");
        Transform slotGrid = GameObject.Find("Slots Grid").transform;
        for (int i = 0; i < itemsToDelete.Length; i++)
        {
            if (itemsToDelete[i].transform.parent != slotGrid)
            {
                Destroy(itemsToDelete[i]);
            }
        }
    }


    void PlaceItemsInSlotsFromCurrentBag()
    {
        for (int i = 0; i < ItemList[CurrentBagNumber].Count; i++)
        {
            if (ItemList[CurrentBagNumber][i].Id != -1)
            {
                Item itemToAdd = ItemList[CurrentBagNumber][i];
                GameObject itemObj = Instantiate(Item);
                itemObj.GetComponent<ItemData>().Item = itemToAdd;
                itemObj.GetComponent<ItemData>().SlotId = i;
                itemObj.GetComponent<ItemData>().BagId = CurrentBagNumber;
                itemObj.GetComponent<ItemData>().Item.Amount = itemToAdd.Amount;
                itemObj.name = itemToAdd.Name;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.transform.SetParent(SlotsList[i].transform, false);
                if (itemToAdd.Stackable && itemToAdd.Amount > 1)
                {
                    itemObj.transform.GetChild(0).GetComponent<Text>().text = itemObj.GetComponent<ItemData>().Item.Amount.ToString();
                }
            }
        }
    }


    public void AddItem(int bagNumber, int slotId, int id) //добавление итема в инвентарь
    {
        Item itemToAdd = new Item();
        switch (id)
        {
            case 0:
                itemToAdd = new Item(0, "Health Potion", "Potion", true, 1, "life_potion");
                break;
            case 1:
                itemToAdd = new Item(1, "Sword 1", "Weapon", false, 0, "sword1");
                break;
            case 2:
                itemToAdd = new Item(2, "Sword 2", "Weapon", false, 0, "sword2");
                break;
        }
        if (itemToAdd.Stackable && CheckIfItemInInventory(itemToAdd, bagNumber, slotId))
        //если итем может стакаться и уже точно такой же есть в инвентаре
        {
            //if (ItemList[bagNumber][slotId].Id == id)
            //{
                ItemData stackAmount = SlotsList[slotId].transform.GetChild(0).GetComponent<ItemData>();
                stackAmount.Item.Amount += ItemList[bagNumber][slotId].Amount;
                stackAmount.transform.GetChild(0).GetComponent<Text>().text = stackAmount.Item.Amount.ToString();
            //}
        }
        else
        {
            if (ItemList[bagNumber][slotId].Id == -1)
            {
                ItemList[bagNumber][slotId] = itemToAdd;
                if (bagNumber == CurrentBagNumber)
                {
                    GameObject itemObj = Instantiate(Item);
                    itemObj.GetComponent<ItemData>().Item = itemToAdd;
                    itemObj.GetComponent<ItemData>().Item.Amount = itemToAdd.Amount;
                    if (itemToAdd.Stackable && itemToAdd.Amount > 1)
                    {
                        itemObj.transform.GetChild(0).GetComponent<Text>().text = itemObj.GetComponent<ItemData>().Item.Amount.ToString();
                    }
                    itemObj.GetComponent<ItemData>().SlotId = slotId;
                    itemObj.name = itemToAdd.Name;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.AddComponent<HealthPotion>();
                    itemObj.transform.SetParent(SlotsList[slotId].transform, false);
                }
            }
        }
    }


    bool CheckIfItemInInventory(Item item, int bagNumber, int slotId) //проверка, лежит ли такой же итем в инвентаре. нужен для стаков
    {
        if (ItemList[bagNumber][slotId].Id == item.Id)
            return true;
        return false;
    }


    public void DestroySlotFrame() //ищет и уничтожает выделение на слоте
    {
        if (GameObject.Find("Slot Frame(Clone)") != null)
        {
            Destroy(GameObject.Find("Slot Frame(Clone)"));
        }
    }


    public void ChooseBagNumberOne() //метод для сумки, которые открывает конкретную сумку нажатием мышки
    {
        if (CurrentBagNumber != 0)
        {
            CurrentBagNumber = 0;
            RemoveItemsFromGrid();
            PlaceItemsInSlotsFromCurrentBag();
            DestroySlotFrame();
        }
    }


    public void SelectBagNumberOneWithDrag() //метод для выделения контура, когда наводим мышку с итемом на сумку
    {
        if (CurrentBagNumber != 0)
            if (Drag)
                GameObject.Find("Bag Button 1").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag with contour", typeof(Sprite)) as Sprite;
    }


    public void DeselectBagNumberOne() //деконтур сумки, когда увели мышку с сумки
    {
        if (CurrentBagNumber != 0)
            if (Drag)
                GameObject.Find("Bag Button 1").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag", typeof(Sprite)) as Sprite;
    }


    public void ChooseBagNumberTwo()
    {
        if (CurrentBagNumber != 1)
        {
            CurrentBagNumber = 1;
            RemoveItemsFromGrid();
            PlaceItemsInSlotsFromCurrentBag();
            DestroySlotFrame();
        }
    }


    public void SelectBagNumberTwoWithDrag()
    {
        if (CurrentBagNumber != 1)
            if (Drag)
                GameObject.Find("Bag Button 2").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag with contour", typeof(Sprite)) as Sprite;
    }


    public void DeselectBagNumberTwo()
    {
        if (CurrentBagNumber != 1)
            if (Drag)
                GameObject.Find("Bag Button 2").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag", typeof(Sprite)) as Sprite;
    }


    public void ChooseBagNumberThree()
    {
        if (CurrentBagNumber != 2)
        {
            CurrentBagNumber = 2;
            RemoveItemsFromGrid();
            PlaceItemsInSlotsFromCurrentBag();
            DestroySlotFrame();
        }
    }


    public void SelectBagNumberThreeWithDrag()
    {
        if (CurrentBagNumber != 2)
            if (Drag)
                GameObject.Find("Bag Button 3").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag with contour", typeof(Sprite)) as Sprite;
    }


    public void DeselectBagNumberThree()
    {
        if (CurrentBagNumber != 2)
            if (Drag)
                GameObject.Find("Bag Button 3").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag", typeof(Sprite)) as Sprite;
    }


    public void ChooseBagNumberFour()
    {
        if (CurrentBagNumber != 3)
        {
            CurrentBagNumber = 3;
            RemoveItemsFromGrid();
            PlaceItemsInSlotsFromCurrentBag();
            DestroySlotFrame();
        }
    }


    public void SelectBagNumberFourWithDrag()
    {
        if (CurrentBagNumber != 3)
            if (Drag)
                GameObject.Find("Bag Button 4").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag with contour", typeof(Sprite)) as Sprite;
    }


    public void DeselectBagNumberFour()
    {
        if (CurrentBagNumber != 3)
            if (Drag)
                GameObject.Find("Bag Button 4").GetComponent<Image>().sprite = Resources.Load("Sprites/Bag", typeof(Sprite)) as Sprite;
    }
}