using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    Animator animator;

    public int hp = 100; // 樹木的生命值
    public int woodAmount = 3; // 砍倒後獲得的木材數量

    // public void TakeDamage(int damage)
    // {
    //     hp -= damage;

    //     if (hp <= 0)
    //     {
    //         Debug.Log("ChopDown");
    //         ChopDown();
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axe"))
        {
            
            attack weapon = other.GetComponent<attack>();
            if (weapon != null)
            {
                hp -= weapon.weaponAttack;
                Debug.Log(hp);
            }

            if (hp <= 0) {
                ChopDown();
            }
        }
    }

    private void ChopDown()
    {
        
        animator.SetBool("isChopDown", true);
        // 樹木被砍倒的處理邏輯
        Debug.Log("Tree chopped down. Obtained " + woodAmount + " wood.");
        playerAddNewItem();
        // 在這裡你可以執行木材獲得的相關操作，例如將木材添加到玩家的背包中
        // 也可以銷毀這個樹木的遊戲物件
        Destroy(gameObject);
    }

    public void playerAddNewItem() {
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
            thisItem.itemHeld += woodAmount;
        }
        InventoryManager.RefreshItem();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}

