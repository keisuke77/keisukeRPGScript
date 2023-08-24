using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class VolumeController : MonoBehaviour
{
    public enum VolumeType { MASTER, BGM, SE }
 
    [SerializeField]
    VolumeType volumeType = 0;
 
    Slider slider;
    soundManager soundManager;
 
    void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = FindObjectOfType<soundManager>();
    }
 
    public void OnValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                soundManager.Volume = slider.value;
                break;
            case VolumeType.BGM:
                soundManager.BgmVolume = slider.value;
                break;
            case VolumeType.SE:
                soundManager.SeVolume = slider.value;
                break;
        }
    }
}