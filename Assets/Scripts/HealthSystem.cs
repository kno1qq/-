using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
 [SerializeField]
    // 控制生命值
    private Slider _healthSlider;

    public float Health
    {
        get
        {
            return _healthSlider.value;
        }

        set
        {
            _healthSlider.value = value;
        }
    }



    public void Damage(float value)
    {
        _healthSlider.value -= value;
    }

    public void Heal(float value)
    {
        _healthSlider.value += value;
    }
    public void RecoverFully()
    {
        _healthSlider.value = _healthSlider.maxValue;
    }
}
