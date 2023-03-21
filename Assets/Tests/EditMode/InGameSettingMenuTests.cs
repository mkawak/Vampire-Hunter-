using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

// This test case is testiing if we pause or resume game, does the time scalse can work correctly
public class InGameSettingMenuTests
{


    [Test]
    public void SetsTimeScaleToZeroTest()
    {
        // Arrange
        var settingMenu = new GameObject("SettingMenu").AddComponent<InGameSettingMenu>();

        // Act
        settingMenu.PauseGame();

        // Assert
        Assert.AreEqual(0f, Time.timeScale);
    }

    [Test]
    public void SetsTimeScaleToOneTest()
    {
        // Arrange
        var settingMenu = new GameObject("SettingMenu").AddComponent<InGameSettingMenu>();

        // Act
        settingMenu.ResumeGame();

        // Assert
        Assert.AreEqual(1f, Time.timeScale);
    }
}
