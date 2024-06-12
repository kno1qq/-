using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public playerStatus playerStatus; // 定義playerStatus腳本的實例變數
    public float baseMoveSpeed=0.7f; // 基礎移動速度
    public int baseHealth=100;
    public int baseAttack=10;
    public GameObject myBag;
    bool isOpen = false;
    public GameObject characterContainer;
    private HealthSystem _healthSystem;
    
    public GameObject LossUi;
    // public GameObject WinUi;

    public GameObject Boss;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStatus = FindObjectOfType<playerStatus>(); // 初始化playerStatus變數
        _healthSystem = GetComponent<HealthSystem>();
        myBag.SetActive(isOpen);
        LossUi.SetActive(false);
        // WinUi.SetActive(false);
    }

    private void FixedUpdate()
    {
        // 獲取水平和垂直軸向的輸入值
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 計算移動方向
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // 正規化移動方向，以避免斜向移動速度增加
        movement.Normalize();

        // 計算移動的速度向量
        Vector2 moveVelocity = movement * baseMoveSpeed;

        // 使用rigidbody的velocity屬性來移動角色
        rb.velocity = moveVelocity;
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // 面向右邊
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if ( baseHealth <= 0) {
            LossUi.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // 與敵人碰撞
        if(other.gameObject.CompareTag("Enemy")) {
            //Debug.Log("被撞");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            baseHealth -= enemy.attack;
            _healthSystem.Damage(enemy.attack);
        }

        if(other.gameObject.CompareTag("Fire")) {
            //Debug.Log("被撞");
            Fire enemy = other.gameObject.GetComponent<Fire>();
            baseHealth -= enemy.attack;
            _healthSystem.Damage(enemy.attack);
        }

        if(other.gameObject.CompareTag("Boss")) {
            //Debug.Log("被撞");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            baseHealth -= enemy.attack;
            _healthSystem.Damage(enemy.attack);
        }
    }

    private void Update() {
        //Debug.Log(hp);
        OpenMyBag();
    }

    void OpenMyBag() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
