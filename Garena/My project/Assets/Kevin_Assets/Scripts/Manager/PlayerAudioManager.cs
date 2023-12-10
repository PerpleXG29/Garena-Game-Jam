using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : AudioManager
{
    [SerializeField] AudioClip[] walkSounds;
    [SerializeField] AudioClip[] runSounds;

    float walkCoolDown = 0.2f;
    float runCoolDown = 0.1f;

    bool isWalk;
    bool isRunning;

    float countCooldownWalk, counRunCoolDown;

    private void Start()
    {
        isWalk = true;
    }

    private void Update()
    {
        if (isWalk)
        {
            counRunCoolDown -= Time.deltaTime;
        }

        if (isRunning)
        {
            counRunCoolDown -= Time.deltaTime;
        }

        if (countCooldownWalk < 0f)
        {
            countCooldownWalk = walkCoolDown;

        }

        if (counRunCoolDown < 0f)
        {
            counRunCoolDown = runCoolDown;

        }

    }


    public void PlayRandomWalkSfx()
    {
        int randomIDx = Random.Range(0, walkSounds.Length);

        PlaySound(walkSounds[randomIDx]);
    }

    public void PlayRandomRunSFX()
    {
        int randomIDx = Random.Range(0, runSounds.Length);

        PlaySound(runSounds[randomIDx]);
    }
}
