using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TimerTests
{
    [Test]
    public void TimerStartSuccessTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var timer = gameObject.AddComponent<Timer>();
        var text = gameObject.AddComponent<TMP_Text>();
        timer.textTimer = text;

        // Act
        timer.StartTimer();

        // Assert
        Assert.IsTrue(timer.isActiveAndEnabled);
    }

    [Test]
    public void TimerStopSuccessTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var timer = gameObject.AddComponent<Timer>();
        var text = gameObject.AddComponent<TMP_Text>();
        timer.textTimer = text;
        timer.StartTimer();

        // Act
        timer.StopTimer();

        // Assert
        Assert.IsFalse(!timer.isActiveAndEnabled);
    }

    [Test]
    public void TimerResetFailureTest()
    {
        // Arrange
        var gameObject = new GameObject();
        var timer = gameObject.AddComponent<Timer>();
        var text = gameObject.AddComponent<TMP_Text>();
        timer.textTimer = text;
        timer.StartTimer();
        timer.StopTimer();
        timer.ResetTimer();

        // Act
        timer.StartTimer();

        // Assert
        Assert.AreEqual("00:00", timer.textTimer.text);
    }
}