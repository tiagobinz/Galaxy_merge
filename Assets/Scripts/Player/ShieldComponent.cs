using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    public delegate void OnShieldUpdate();

    [SerializeField] GameObject shieldObject = null;
    [SerializeField] KeyCode shieldKey = KeyCode.None;

    public OnShieldUpdate onShieldUpdate;

    float shieldMax = 5;
    float shield = 5;
    bool blockShieldRegen;
    Coroutine blockShieldRegenForTimeRoutine;

    void Update()
    {
        if (Input.GetKey(shieldKey))
        {
            if (shield > 0)
            {
                ShieldEnabled();
            }
            else
            {
                ShieldDisabled();
            }
        }
        else if (!blockShieldRegen && shield < shieldMax)
        {
            shield = Mathf.Clamp(shield + Time.deltaTime, 0, shieldMax);
            if (onShieldUpdate != null)
            {
                onShieldUpdate.Invoke();
            }
        }

        if (Input.GetKeyUp(shieldKey))
        {
            ShieldDisabled();
        }
    }

    void ShieldEnabled()
    {
        shieldObject.SetActive(true);
        shield = Mathf.Clamp(shield - Time.deltaTime, 0, shieldMax);
        if (onShieldUpdate != null)
        {
            onShieldUpdate.Invoke();
        }
    }

    void ShieldDisabled()
    {
        shieldObject.SetActive(false);
        if (blockShieldRegenForTimeRoutine != null)
        {
            StopCoroutine(blockShieldRegenForTimeRoutine);
        }
        blockShieldRegenForTimeRoutine = StartCoroutine(BlockShieldRegenForTime(5));
    }

    IEnumerator BlockShieldRegenForTime(float time)
    {
        blockShieldRegen = true;
        yield return new WaitForSeconds(time);
        blockShieldRegen = false;
    }

    public float GetShield()
    {
        return shield;
    }

    public float GetShieldMax()
    {
        return shieldMax;
    }
}
