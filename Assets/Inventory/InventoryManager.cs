using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    // public Slot slotPrefab;
    public Text itemInfomation;
    public GameObject emptySlot;

    public static GameObject playerWeapon;
    static float GO;
    public List<GameObject> slots = new List<GameObject>();
    private void Awake() {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    public void Start() {
        playerWeapon = GameObject.Find("playerWeapon"); // 根据实际情况设置正确的游戏对象名称
    }

    private void OnEnable() {
        RefreshItem();
        instance.itemInfomation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription) {
        instance.itemInfomation.text = itemDescription;
    }

    /*public static void CreateNewItem(Item item) {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/
    
    public static void RefreshItem() {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for (int i = 0; i < instance.myBag.itemList.Count; i++) {
            // CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }

    public static void equip(GameObject weapon) {
        foreach (Transform child in playerWeapon.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject instantiatedWeapon = Instantiate(weapon, playerWeapon.transform.position, playerWeapon.transform.rotation);
        instantiatedWeapon.transform.SetParent(playerWeapon.transform);
        // Instantiate(weapon, playerWeapon.transform);
    } 
}
