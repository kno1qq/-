using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject winUIPrefab;

    public Item thisItem;
    public Inventory playerInventory;

    public float speed=1f;
    public Vector2 direction;

    private bool isKnockedBack = false;

    public int hp = 10;
    public int attack = 10;

    Vector2 velocity;
    public new Rigidbody2D rigidbody;
    // Start is called before the first frame update

    private void Awake()
    {
        rigidbody=GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;
                directionToPlayer.Normalize();
                velocity = directionToPlayer * speed;
                rigidbody.velocity = velocity;
            }
        }
        if (hp <= 0) {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            attack weapon = other.GetComponent<attack>();
            if (weapon != null)
            {
                hp -= weapon.weaponAttack;
                // 計算擊退方向
                Vector2 knockbackDirection = transform.position - other.transform.position;
                knockbackDirection.Normalize();

                // 設定擊退力量
                float knockbackForce = 2f;

                // 暫停或停止敵人的運動
                rigidbody.velocity = Vector2.zero;
                isKnockedBack = true;

                // 套用擊退力量到剛體
                rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

                // 延遲一段時間後恢復敵人的運動
                StartCoroutine(ResumeMovement(0.1f));
            }
        }
    }



    private IEnumerator ResumeMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        isKnockedBack = false;
    }
    
    
    private void Die() {
        Debug.Log("死了");

        Destroy(gameObject);
        GameObject canvasObject = GameObject.FindWithTag("Canvas");
        if (canvasObject != null)
        {
            GameObject winUIObject = Instantiate(winUIPrefab, Vector3.zero, Quaternion.identity);
            winUIObject.transform.SetParent(canvasObject.transform, false);
            winUIObject.SetActive(true);
        }
        else
        {
            Debug.LogError("找不到標籤為 'Canvas' 的物件");
        }
            // GameObject winUIObject = Instantiate(WinUI, Vector3.zero, Quaternion.identity);
            // winUIObject.transform.SetParent(GameObject.FindWithTag("Canvas").transform, false);
            // winUIObject.SetActive(true);
            // playerAddNewItem();
            // WinUI.SetActive(true);
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
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
