using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
  public static void PlaySound()
    {
        GameObject soundGameobject = new GameObject("Sound");
        AudioSource audioSource = soundGameobject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(MenuController.instance.soundBall);
    }
}
