using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperClue : MonoBehaviour
{
    private string TextClue;
    bool isTriggered;
    public void SetPaperText(string text)
    {
        TextClue = text;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.F) && other.CompareTag("Player") && !isTriggered)
        {
            ClueTextUI.OnTextTriggered.Invoke(TextClue);

        }
    }

}
