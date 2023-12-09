using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ClueTextUI : MonoBehaviour
{
    [SerializeField] TMP_Text _clueText;
    [SerializeField] GameObject _imageObj;

    public static Action<string> OnTextTriggered;

    bool isActivated = false;

    private void Start()
    {
        OnTextTriggered += SetText;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && isActivated == true)
        {
            _imageObj.SetActive(false);
            isActivated = false;
        }
    }

    public void SetText(string Text)
    {
        _imageObj.SetActive(true);
        _clueText.SetText(Text);

        isActivated = true;
    }

}
