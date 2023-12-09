using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    const int spawnMax = 3;

    [SerializeField] GameObject _obj;
    [SerializeField] Transform[] _spawnLocation;
    [SerializeField] Target _target;

    bool[] checkPlace;

    private void Start()
    {
        int count = 0;
        checkPlace = new bool[_spawnLocation.Length];

        while (count < spawnMax)
        {
            int randomIdx = Random.Range(0, _spawnLocation.Length);

            if (checkPlace[randomIdx] == false)
            {
                GameObject newObj =  Instantiate(_obj, _spawnLocation[randomIdx].position, Quaternion.identity);
                newObj.GetComponentInChildren<ZombieStateMachine>().InitializeTarget(_target);

                checkPlace[randomIdx] = true;
                count++;
            }
        }


    }

}
