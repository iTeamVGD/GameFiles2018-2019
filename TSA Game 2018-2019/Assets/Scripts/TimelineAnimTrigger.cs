﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineAnimTrigger : MonoBehaviour {

    public PlayerController pc;
    public GameController gc;

    public Animator characterBodyAnim;
    public ParticleSystem cubeWaveParticleSystem;

    public bool lockIntoAnim;
    public bool lockIntoAnimRunner;

    public bool reachForCubeTrigger;
    public bool reachForCubeTriggerRunner;

    public bool cubeWaveTrigger;
    public bool cubeWaveTriggerRunner;

    public bool exitNothingIdle;
    public bool exitNothingIdleRunner;

    public bool enterNothingIdle;
    public bool enterNothingIdleRunner;

    public bool quitGame;
    public bool quitGameRunner;

    public GameObject introRoomObj;
    public GameObject meteor;

    public bool smokeStopTrigger;
    public bool smokeStopTriggerRunner;
    public ParticleSystem smokeParticle;

    public bool sendOutCubeTrigger;
    public bool sendOutCubeTriggerRunner;
    public GameObject cube;

    // Update is called once per frame
    void Update () {
        if (lockIntoAnim && !lockIntoAnimRunner)
        {
            lockIntoAnim = false;
            pc.lockIntoAnim = true;
            characterBodyAnim.SetBool("canSwitch", false);
            lockIntoAnimRunner = true;
        }
        if (reachForCubeTrigger && !reachForCubeTriggerRunner)
        {
            reachForCubeTrigger = false;
            characterBodyAnim.Play("ReachingForCube");
            reachForCubeTriggerRunner = true;
        }
        if(cubeWaveTrigger && !cubeWaveTriggerRunner)
        {
            cubeWaveTrigger = false;
            cubeWaveParticleSystem.Play();
            cubeWaveTriggerRunner = true;
        }
        if (exitNothingIdle && !exitNothingIdleRunner)
        {
            exitNothingIdle = false;
            characterBodyAnim.SetBool("ExitNothingIdle", true);
            Destroy(introRoomObj);
            Destroy(meteor);
            smokeParticle.Play();
            exitNothingIdleRunner = true;
            pc.lockIntoAnim = false;
        }
        if (enterNothingIdle && !enterNothingIdleRunner)
        {
            enterNothingIdle = false;
            characterBodyAnim.SetBool("ExitNothingIdle", false);
            characterBodyAnim.Play("NothingIdle");
            enterNothingIdleRunner = true;
        }
        if (smokeStopTrigger && !smokeStopTriggerRunner)
        {
            smokeStopTrigger = false;
            smokeParticle.Stop();
            gc.npcs.SetActive(true);
            smokeStopTriggerRunner = true;
        }
        if (sendOutCubeTrigger && !sendOutCubeTriggerRunner)
        {
            sendOutCubeTrigger = false;
            characterBodyAnim.Play("HandOutForCube");
            cube.SetActive(true);
            sendOutCubeTriggerRunner = true;
        }
        if (quitGame && !quitGameRunner)
        {
            quitGameRunner = true;
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
