using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueRandomizerManager : MonoBehaviour
{
    Location clueLocation;
    Location vialLocation;

    List<Vial> Vials = new List<Vial>();

    [Header("Header")]
    [SerializeField] VialAddressClue[] _allCluesLoc;
    [SerializeField] SpawnManager _clueSpawnManager;
    [SerializeField] SpawnManager _hintSpawnManager;

    [Header("VialPrefab")]
    [SerializeField] GameObject _vial1;
    [SerializeField] GameObject _vial2;
    [SerializeField] GameObject _vial3;

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(CreateRandomizeCluesAndHints());
    }

    private bool CheckForDuplicateLoc(Location clueLoc, Location vialLoc)
    {
        foreach(var vial in Vials)
        {
            if(vial.ClueLocation == clueLoc || vial.VialLocation == vialLoc)
            {
                return true;
            }
        }

        return false;
    }


    IEnumerator CreateRandomizeCluesAndHints()
    {
        //CREATE RANDOM CLUE AND VIAL LOC
        for (int i = 0; i < 3; i++)
        {
            int randomClueLocation = Random.Range(0, System.Enum.GetNames(typeof(Location)).Length -1);
            int randomVialLocation = Random.Range(0, System.Enum.GetNames(typeof(Location)).Length -1);

            while (randomClueLocation == randomVialLocation)
            {
                randomClueLocation = Random.Range(0, System.Enum.GetNames(typeof(Location)).Length -1);
                randomVialLocation = Random.Range(0, System.Enum.GetNames(typeof(Location)).Length -1);
            }

            clueLocation = (Location)randomClueLocation;
            vialLocation = (Location)randomVialLocation;

            if (!CheckForDuplicateLoc(clueLocation, vialLocation))
            {
                Vial tempVial = new(clueLocation, vialLocation);
                Vials.Add(tempVial);
            }
            else
            {
                i--;
            }
        }

        yield return new WaitForEndOfFrame();

        //Create Random CLue for Vial Loc
        foreach (var vial in Vials)
        {
            VialAddressClue tempClue = null;
            foreach (var clue in _allCluesLoc)
            {
                if (clue.VialLocation == vial.VialLocation)
                {
                    tempClue = clue;
                    break;
                }

            }

            int randomIdx = Random.Range(0, tempClue.vialClueText.Length);
            vial.vialLocClueText = tempClue.vialClueText[randomIdx];
        }

        yield return new WaitForEndOfFrame();

        //Register Random Clue and Vial Position
        foreach (var vial in Vials)
        {
            vial.SetTransform(_clueSpawnManager.GetSpawnClueLoc(vial.ClueLocation), _hintSpawnManager.GetSpawnClueLoc(vial.VialLocation));
        }



        yield return new WaitForEndOfFrame();
        //Put Text Data to the Paper



    }

}


public enum Location
{
    ChemistryLab,
    BiologyLab,
    HumanExperimentLab,
    Bathroom,
    MainRoom
}