using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AudioManagerTests
{
    [Test]
    public void NotPlaySFXSuccessTest()
    {
        // Arrange
        var audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
        audioManager.sfxSource = audioManager.gameObject.AddComponent<AudioSource>();

        // Act
        //audioManager.PlaySFX("InvalidSFXName");

        // Assert
        Assert.IsFalse(audioManager.sfxSource.isPlaying);
    }

    [Test]
    public void SetMusicVolumeSuccessTest()
    {
        // Arrange
        var audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
        audioManager.musicSource = audioManager.gameObject.AddComponent<AudioSource>();

        // Act
        audioManager.MusicVolume(0.5f);

        // Assert
        Assert.AreEqual(0.5f, audioManager.musicSource.volume);
    }

    [Test]
    public void SetSFXVolumeSuccessTest()
    {
        // Arrange
        var audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
        audioManager.sfxSource = audioManager.gameObject.AddComponent<AudioSource>();

        // Act
        audioManager.SFXVolume(0.5f);

        // Assert
        Assert.AreEqual(0.5f, audioManager.sfxSource.volume);
    }
}
