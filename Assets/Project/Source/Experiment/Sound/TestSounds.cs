using System;
using AudioSystem;
using UnityEngine;
using UnityEngine.UI;

public class TestSounds : MonoBehaviour
{
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;

    private SoundBuilder _soundBuilder;
    
    public SoundData _data1;
    public SoundData _data2;
    
    
    private void Awake()
    {
        _button1.onClick.AddListener(PlaySound1);
        _button2.onClick.AddListener(PlaySound2);
        
        _soundBuilder = SoundManager.Instance.CreateSoundBuilder();
    }

    private void PlaySound1()
    {
        _soundBuilder
            .WithRandomPitch()
            .Play(_data1);
    }

    private void PlaySound2()
    {
       _soundBuilder
           .WithRandomPitch()
           .Play(_data2);
    }
}
