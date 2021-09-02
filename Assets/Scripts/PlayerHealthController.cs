using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [Header("Properties & References")]
    [SerializeField]
    private float health;
    [SerializeField]
    private Slider healthBarSlider;

    private void Awake()
    {
        healthBarSlider.maxValue = health;
    }
    public void ReduceHealth(int damage)
    {
        healthBarSlider.value -= damage;
        health = healthBarSlider.value;
    }
}
