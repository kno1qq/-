using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public int slotNumber;
    public string slotInfo;
    public string slotName;
    public GameObject itemInSlot;

    public GameObject slotObject;

    public Inventory playerInventory;

    public Item stonePickaxe, stoneaxe, stoneSword;
    public Item IronPickaxe, Ironaxe, IronSword;
    public Item GoldPickaxe, Goldaxe, GoldSword;
    public Item Wood;

    public bool canEquip;

    public void ItemOnClicked() {
        InventoryManager.UpdateItemInfo(slotInfo);

        Debug.Log(slotItem);

        if (canEquip) InventoryManager.equip(slotObject);

        else if (slotName == "Rock") {
            if (slotNumber >= 15 && Wood.itemHeld >= 15) {
                levelUpTool(stonePickaxe, slotItem);
                levelUpTool(stoneaxe, slotItem);
                levelUpTool(stoneSword, slotItem);
            }
        }

        else if (slotName == "Iron") {
            if (slotNumber >= 15 && Wood.itemHeld >= 15) {
                levelUpTool(IronPickaxe, slotItem);
                levelUpTool(Ironaxe, slotItem);
                levelUpTool(IronSword, slotItem);
            }
        }

        else if (slotName == "Gold") {
            if (slotNumber >= 15 && Wood.itemHeld >= 15) {
                levelUpTool(GoldPickaxe, slotItem);
                levelUpTool(Goldaxe, slotItem);
                levelUpTool(GoldSword, slotItem);
            }
        }
    }

    void levelUpTool(Item thisItem, Item ROCK) {
        ROCK.itemHeld -= 5;
        Wood.itemHeld -= 5;
        if (!playerInventory.itemList.Contains(thisItem)) {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++) {
                if (playerInventory.itemList[i] == null) {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
    
    public void SetupSlot(Item item) {
        if(item == null) {
            itemInSlot.SetActive(false);
            return;
        }

        slotItem = item;
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotNumber = item.itemHeld;
        slotInfo = item.itemInfo;
        slotObject = item.itemObject;
        canEquip = item.equip;
        slotName = item.itemName;
    }
}
