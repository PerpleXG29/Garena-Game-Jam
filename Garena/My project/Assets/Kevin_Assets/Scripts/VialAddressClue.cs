using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VialAddressClue", menuName = "VialAddressClue")]
public class VialAddressClue : ScriptableObject
{
    public Location VialLocation;
    [TextArea(3,10)]public string[] vialClueText;
}
