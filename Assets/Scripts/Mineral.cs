using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    Animator animator;

    public int hp = 100; // 礦物的生命值
    public int MineralAmount = 3; // 砍倒後獲得的礦物數量

    // public void TakeDamage(int damage)
    // {
    //     hp -= damage;

    //     if (hp <= 0)
    //     {
    //         Mine();
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickaxe"))
        {
            attack weapon = other.GetComponent<attack>();
            if (weapon != null)
            {
                Debug.Log(hp);
                hp -= weapon.weaponAttack;
            }

            if (hp <= 0) 
            {
                Mine();
            }
        }
    }

    private void Mine()
    {
        animator.SetBool("isMinded", true);
        // 樹木被砍倒的處理邏輯
        Debug.Log("Mineral be Mined. Obtained " + MineralAmount );
        playerAddNewItem();
        Debug.Log("加完");
        Destroy(gameObject);
        Debug.Log("刪除");
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
            thisItem.itemHeld += MineralAmount;
        }
        InventoryManager.RefreshItem();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}

