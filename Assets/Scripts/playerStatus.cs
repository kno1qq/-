using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public  player player;
    public float currentMoveSpeed; // 當前移動速度
    public int  currentAttack; // 當前移動速度



    private HealthSystem _healthSystem;
    Coroutine speedBuffCoroutine; // 速度增益的協程參考
    Coroutine attackBuffCoroutine; // 速度增益的協程參考
    Coroutine healthBuffCoroutine; // 速度增益的協程參考

    private void Start()
    {
        player.baseMoveSpeed = 0.7f; // 初始化基礎移動速度
        player.baseAttack=10;
        player.baseHealth =100;

        currentMoveSpeed = player.baseMoveSpeed; // 初始化當前移動速度
        currentAttack = player.baseAttack; // 初始化當前移動速
        _healthSystem = GetComponent<HealthSystem>();
        
       
    }

    private void Update()
    {
        // 在Update中實現玩家的移動邏輯，根據currentMoveSpeed移動玩家的位置
        float moveX = Input.GetAxis("Horizontal") * currentMoveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    public void ApplyAttackBuffToPlayer(float duration, int buffValue)
    {
        if (attackBuffCoroutine != null)
        {
            // 如果已經有速度增益效果在進行中，則停止該協程
            StopCoroutine(attackBuffCoroutine);
        }

        currentAttack *= buffValue; // 增加速度增益值

        // 開始計時，過指定的持續時間後恢復基礎速度
        attackBuffCoroutine = StartCoroutine(RemoveAttackBuffAfterDuration(duration));
    }

    public void ApplySpeedBuff(float duration,float buffValue)
    {
        if (speedBuffCoroutine != null)
        {
            // 如果已經有速度增益效果在進行中，則停止該協程
            StopCoroutine(speedBuffCoroutine);
        }

        currentMoveSpeed += buffValue; // 增加速度增益值

        // 開始計時，過指定的持續時間後恢復基礎速度
        speedBuffCoroutine = StartCoroutine(RemoveSpeedBuffAfterDuration(duration));
    }
    
    public void ApplyHealthBuff(int buffValue)
    {
        player.baseHealth += buffValue;
        _healthSystem.Heal(50);
        if(player.baseHealth>100)
        {
            player.baseHealth=100;
        }
      

        Debug.Log(player.baseHealth);
    }

    IEnumerator RemoveSpeedBuffAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        currentMoveSpeed = player.baseMoveSpeed; // 恢復基礎速度
        speedBuffCoroutine = null; // 清空協程參考
    }

    IEnumerator RemoveAttackBuffAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        currentAttack = player.baseAttack; // 恢復基礎速度
        attackBuffCoroutine = null; // 清空協程參考
    }
}
