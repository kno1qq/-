using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType
{
    Axe,
    Sword,
    Pickaxe
}

public class attack : MonoBehaviour
{
    public Animator anim;
    public int weaponAttack = 5;
    public ToolType currentTool;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        switch (currentTool)
        {
            case ToolType.Axe:
                AttackTree();
                break;
            case ToolType.Sword:
                AttackMonster();
                break;
            case ToolType.Pickaxe:
                AttackMineral();
                break;
        }
    }

    private void AttackTree()
    {
        // 攻擊樹木的邏輯
        Debug.Log("Attacking tree");
    }

    private void AttackMonster()
    {
        // 攻擊怪物的邏輯
        Debug.Log("Attacking monster");
    }

    private void AttackMineral()
    {
        // 攻擊礦物的邏輯
        Debug.Log("Attacking mineral");
    }
}