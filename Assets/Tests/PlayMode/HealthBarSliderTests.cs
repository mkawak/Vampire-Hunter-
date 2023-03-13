using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class HealthBarSliderTests
{
    private HealthBar healthBar;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return SceneManager.LoadSceneAsync("PlayerUI");
        healthBar = GameObject.FindObjectOfType<HealthBar>();
    }

    [UnityTest]
    public IEnumerator HealthBarSliderValueSuccessTest()
    {
        healthBar.maxHealth = 100;
        healthBar.health = 50;
        healthBar.Update();

        Slider slider = healthBar.healthbar;
        Assert.AreEqual(50f, slider.value);

        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarSliderTakeDamageSuccessTest()
    {
        healthBar.maxHealth = 100;
        healthBar.health = 50;
        healthBar.TakeDamage(20f);
        healthBar.Update();

        Slider slider = healthBar.healthbar;
        Assert.AreEqual(30f, slider.value);

        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarSliderHealSuccessTest()
    {
        healthBar.maxHealth = 100;
        healthBar.health = 50;
        healthBar.Heal(10f);
        healthBar.Update();

        Slider slider = healthBar.healthbar;
        Assert.AreEqual(60f, slider.value);

        yield return null;
    }

    [UnityTest]
    public IEnumerator HealthBarSliderDieSuccessTest()
    {
        healthBar.maxHealth = 100;
        healthBar.health = 0;
        healthBar.Die();

        GameObject dieWindow = healthBar.DieWindow;
        Assert.IsTrue(dieWindow.activeSelf);

        yield return null;
    }
}
