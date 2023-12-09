using System.Collections;
using UnityEngine;
[System.Serializable]
public class Vial
{
    public Location ClueLocation;
    public Location VialLocation;
    public string vialLocClueText;

    public Transform ClueSpawnTransform;
    public Transform VialSpawnTransform;

    public Vial(Location clueLoc, Location vialLoc)
    {
        ClueLocation = clueLoc;
        VialLocation = vialLoc;
    }

    public void SetTransform(Transform clueTrans, Transform vialSpawn)
    {
        ClueSpawnTransform = clueTrans;
        VialSpawnTransform = vialSpawn;
    }

}

public enum ClueDiff
{
    Easy,
    Med,
    Hard
}
