using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    const int spawnMax = 3;

    [SerializeField] GameObject _obj;
    [SerializeField] Transform[] _spawnLocation;
    [SerializeField] Target _target;
    [SerializeField] AudioManager _audioManager;

    bool[] checkPlace;
    List<ZombieStateMachine> zombieStates = new List<ZombieStateMachine>();
    bool isPlayingAmbience = false;
    bool isPlayingChase = false;
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
                ZombieStateMachine zsm = newObj.GetComponentInChildren<ZombieStateMachine>();

                zsm.InitializeTarget(_target, this);
                checkPlace[randomIdx] = true;
                zombieStates.Add(zsm);
                count++;
            }
        }

        PlayAmbienceSong();
    }


    private void Update()
    {
       
    }


    public void CheckForSong()
    {
        bool check = false;

        foreach (var zombie in zombieStates)
        {
            if (zombie.IsChasing)
            {
                check = true;
                PlayChaseSong();
                break;
            }
        }

        if (check == false)
        {
            PlayAmbienceSong();
        }
    }


    private void PlayAmbienceSong()
    {
        if (isPlayingAmbience && !isPlayingChase) return;
        _audioManager.StopPlayingPrivateSource();
        _audioManager.PlaySfx("Ambience");

        isPlayingChase = false;
        isPlayingAmbience = true;
    }

    private void PlayChaseSong()
    {
        if (isPlayingChase && !isPlayingAmbience) return;
        _audioManager.StopPlayingPrivateSource();
        _audioManager.PlaySfx("Chase");

        isPlayingAmbience = false;
        isPlayingChase = true;
    }


}
