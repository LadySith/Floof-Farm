using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource[] mySounds;

    private AudioSource dewDrop;
    private AudioSource step1;
    private AudioSource dewDrop2;
    private AudioSource squeak;
    private AudioSource bell;
    private AudioSource page;

    // Start is called before the first frame update
    void Start()
    {
        mySounds = GetComponents<AudioSource>();

        dewDrop = mySounds[0];
        step1 = mySounds[1];
        dewDrop2 = mySounds[2];
        squeak = mySounds[3];
        bell = mySounds[4];
        page = mySounds[5];
    }

    public void PlayDewDrop()
    {
        dewDrop.Play();
    }

    public void PlayStep()
    {
        step1.Play();
    }

    public void PlayDewDrop2()
    {
        dewDrop2.Play();
    }

    public void PlaySqueak()
    {
        squeak.Play();
    }

    public void PlayBell()
    {
        bell.Play();
    }
    public void PlayPage()
    {
        page.Play();
    }
}
