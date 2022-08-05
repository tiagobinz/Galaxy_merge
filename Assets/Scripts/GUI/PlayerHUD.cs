using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] GameObject playerReference = null;
    [SerializeField] Slider healthSlider = null;
    [SerializeField] Slider shieldSlider = null;

    Health health;
    ShieldComponent shield;

    void Awake()
    {
        if (health = playerReference.GetComponent<Health>())
        {
            health.onHealthChanged += OnHealthChanged;
            health.onDie += OnDie;
        }

        if (shield = playerReference.GetComponent<ShieldComponent>())
        {
            shield.onShieldUpdate += OnShieldUpdate;
        }
    }

    void OnHealthChanged()
    {
        if (healthSlider)
        {
            healthSlider.value = (float)health.GetHealth() / health.GetMaxHealth();
        }
    }

    void OnDie()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup)
        {
            canvasGroup.alpha = 0.2f;
        }

        if (healthSlider)
        {
            healthSlider.value = 0;
        }
        
        if (shieldSlider)
        {
            shieldSlider.value = 0;
        }
    }

    void OnShieldUpdate()
    {
        if (shieldSlider)
        {
            shieldSlider.value = (float)shield.GetShield() / shield.GetShieldMax();
        }
    }
}
