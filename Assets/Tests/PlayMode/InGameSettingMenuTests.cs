using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class InGameSettingMenuTests
{
    private InGameSettingMenu settingMenu;

    [SetUp]
    public void Setup()
    {
        // Load the scene
        SceneManager.LoadScene("PlayerUI"); 

        // Find the script object
        settingMenu = GameObject.FindObjectOfType<InGameSettingMenu>(); 
        
        // Ensure that time is running normally
        Time.timeScale = 1f;
    }

    [UnityTest]
    public IEnumerator TimeScaleIsOneSuccessTest()
    {
        // Set time scale to zero
        Time.timeScale = 0f;

        // Call method to resume the game
        settingMenu.ResumeGame();

        // Wait for next frame to update UI
        yield return null;

        // Assert that the time scale is now one
        Assert.AreEqual(1f, Time.timeScale); 
    }

    [UnityTest]
    public IEnumerator ReloadGameSuccessTest()
    {
        // Arrange
        SceneManager.LoadScene("PlayerUI");
        yield return null;

        // Act
        InGameSettingMenu settingMenuScript = Object.FindObjectOfType<InGameSettingMenu>();
        settingMenuScript.Restart();

        // Assert
        Assert.AreEqual("PlayerUI", SceneManager.GetActiveScene().name);

        // Clean up
        yield return null;
    }
}
