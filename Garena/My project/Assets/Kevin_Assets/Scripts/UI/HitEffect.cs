using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitEffect : MonoBehaviour
{
    int stringToHash = Animator.StringToHash("TriggerDamage");

    const float DisableTimer = 0.4f;
    [SerializeField] Image _image;

    [Header("Sprite")]
    [SerializeField] Sprite _healthLossSprite1;
    [SerializeField] Sprite _healthLossSprite2;

    [Header("Reference")]
    [SerializeField] GameObject _objects;
    [SerializeField] Animator _animator;

    int count = 2;

    private void Start()
    {
        _image.sprite = _healthLossSprite1;

    }


    public void TriggerHitVFX()
    {
        count++;

        StopAllCoroutines();
        StartCoroutine(DeactivateImage());

        if(count >= 3)
        {
            _animator.SetTrigger(stringToHash);
        }
        _objects.SetActive(true);
    }


    IEnumerator DeactivateImage()
    {
        yield return new WaitForSeconds(DisableTimer);
        _image.sprite = _healthLossSprite2;
        _objects.SetActive(false);
    }
}
