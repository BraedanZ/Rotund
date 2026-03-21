using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource big1;
    private AudioSource big2;
    private AudioSource big3;
    private AudioSource big4;
    private AudioSource big5;

    private AudioSource[] bigs;

    private AudioSource small1;
    private AudioSource small2;
    private AudioSource small3;
    private AudioSource small4;
    private AudioSource small5;

    private AudioSource[] smalls;

    private AudioSource die;

    void Start()
    {
        big1 = GameObject.FindGameObjectWithTag("BigSound1").GetComponent<AudioSource>();
        big2 = GameObject.FindGameObjectWithTag("BigSound2").GetComponent<AudioSource>();
        big3 = GameObject.FindGameObjectWithTag("BigSound3").GetComponent<AudioSource>();
        big4 = GameObject.FindGameObjectWithTag("BigSound4").GetComponent<AudioSource>();
        big5 = GameObject.FindGameObjectWithTag("BigSound5").GetComponent<AudioSource>();

        small1 = GameObject.FindGameObjectWithTag("SmallSound1").GetComponent<AudioSource>();
        small2 = GameObject.FindGameObjectWithTag("SmallSound2").GetComponent<AudioSource>();
        small3 = GameObject.FindGameObjectWithTag("SmallSound3").GetComponent<AudioSource>();
        small4 = GameObject.FindGameObjectWithTag("SmallSound4").GetComponent<AudioSource>();
        small5 = GameObject.FindGameObjectWithTag("SmallSound5").GetComponent<AudioSource>();

        die = GameObject.FindGameObjectWithTag("DieSound").GetComponent<AudioSource>();

        bigs = new AudioSource[5];
        bigs[0] = big1;
        bigs[1] = big2;
        bigs[2] = big3;
        bigs[3] = big4;
        bigs[4] = big5;

        smalls = new AudioSource[5];
        smalls[0] = small1;
        smalls[1] = small2;
        smalls[2] = small3;
        smalls[3] = small4;
        smalls[4] = small5;
    }

   public void PlayBigSound() {
        bigs[Random.Range(0, 5)].Play();
   }

   public void PlaySmallSound() {
        smalls[Random.Range(0, 5)].Play();
   }

   public void PlayDieSound() {
        die.Play();
   }
}
