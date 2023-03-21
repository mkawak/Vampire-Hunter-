using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettingMenuTests
{
    [Test]
    public void PauseGame_SetsTimeScaleToZero()
    {
        // Arrange
        var settingMenu = new GameObject("SettingMenu").AddComponent<InGameSettingMenu>();

        // Act
        settingMenu.PauseGame();

        // Assert
        Assert.AreEqual(0f, Time.timeScale);
    }

    [Test]
    public void ResumeGame_SetsTimeScaleToOne()
    {
        // Arrange
        var settingMenu = new GameObject("SettingMenu").AddComponent<InGameSettingMenu>();

        // Act
        settingMenu.ResumeGame();

        // Assert
        Assert.AreEqual(1f, Time.timeScale);
    }
}
