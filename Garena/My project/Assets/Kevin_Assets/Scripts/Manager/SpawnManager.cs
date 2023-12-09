using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] _spawnBioLocation;
    [SerializeField] Transform[] _spawnChemLabLocation;
    [SerializeField] Transform[] _spawnHumanExLabLocation;
    [SerializeField] Transform[] _spawnToiletLocation;

    public Transform GetSpawnClueLoc(Location loc)
    {
        if(loc == Location.Bathroom)
        {
            return _spawnToiletLocation[Random.Range(0, _spawnToiletLocation.Length)];
        }


        else if(loc == Location.BiologyLab)
        {
            return _spawnBioLocation[Random.Range(0, _spawnBioLocation.Length)];
        }


        else if(loc == Location.ChemistryLab)
        {
            return _spawnChemLabLocation[Random.Range(0, _spawnChemLabLocation.Length)];
        }

        else if(loc == Location.HumanExperimentLab)
        {
            return _spawnHumanExLabLocation[Random.Range(0, _spawnHumanExLabLocation.Length)];
        }

        return null;
    }


}
