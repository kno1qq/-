using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Health : MonoBehaviour
{
    bool isOpen;
    Animator animator;
    public playerStatus playerStatus; // 定義PlayerController類別的實例變數
    public GameObject player;

    public Item coin;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerStatus = FindObjectOfType<playerStatus>(); // 初始化playerStatus變數
    }

    private void ApplyHealthBuffToPlayer()
    {
        playerStatus.ApplyHealthBuff(50); // 增加2秒的移動速度增益，增益值為5.0

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject && !isOpen)
            {
                if (coin.itemHeld >= 3) {
                    coin.itemHeld -= 3;
                    InventoryManager.RefreshItem();
                    isOpen = true;
                    GetComponent<Collider2D>().enabled = false;
                    Destroy(GetComponent<Rigidbody2D>());
                    animator.SetBool("isOpen", true);
                    ApplyHealthBuffToPlayer();
                    StartCoroutine(DestroyBoxAfterAnimation());
                    Debug.Log("血量恢復"); // 顯示獲得速度buff的訊息
                }
            }
        }
    }

    IEnumerator DestroyBoxAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
