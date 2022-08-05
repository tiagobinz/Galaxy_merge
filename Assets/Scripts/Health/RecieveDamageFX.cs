using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class RecieveDamageFX : MonoBehaviour
{
    [SerializeField] GameObject Explosion_VFX = null;
    [SerializeField] AudioClip Damage_SFX = null;
    [SerializeField] Material damageMaterial = null;
    [SerializeField] MeshRenderer[] meshRenderers = null;

    Dictionary<MeshRenderer, Material[]> originalMaterials = null;
    Coroutine currentDamageMaterialRoutine = null;

    void Start()
    {
        originalMaterials = new Dictionary<MeshRenderer, Material[]>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            originalMaterials.Add(meshRenderer, meshRenderer.materials);
        }

        Health h = GetComponent<Health>();
        if (h)
        {
            h.onDie += DoExplosion;
            h.onTakeDamage += DoDamageEffect;
        }
    }

    void DoExplosion()
    {
        if (Explosion_VFX)
        {
            Instantiate(Explosion_VFX, transform.position, transform.rotation);
            CameraShake.Shake(0.2f, 0.5f);
        }

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }

    void DoDamageEffect(int amount)
    {
        CameraShake.Shake(0.1f, 0.1f);
        if (currentDamageMaterialRoutine != null)
        {
            StopCoroutine(currentDamageMaterialRoutine);
        }
        currentDamageMaterialRoutine = StartCoroutine(DamageMaterialFeedback());
        if (Damage_SFX)
        {
            AudioSource.PlayClipAtPoint(Damage_SFX, transform.position, 10);
        }
    }

    IEnumerator DamageMaterialFeedback()
    {
        foreach(MeshRenderer meshRenderer in meshRenderers)
        {
            if (meshRenderer)
            {
                Material[] newMaterials = new Material[meshRenderer.materials.Length];
                for (int i = 0; i < newMaterials.Length; i++)
                {
                    newMaterials[i] = damageMaterial;
                }

                meshRenderer.materials = newMaterials;

                yield return new WaitForSeconds(.02f);
                
                meshRenderer.materials = originalMaterials[meshRenderer];
            }
            else
            {
                yield return null;
            }
        }
    }
}
