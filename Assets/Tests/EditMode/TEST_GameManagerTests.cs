using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;


//This test case is testing the upgrade weapon system
public class TESTGameManagerTest
{
/*    [Test]
    public void TestComboWeapons()
    {
        TEST_GameManager gameManager = new GameObject().AddComponent<TEST_GameManager>();

        Weapon weapon1 = new GameObject().AddComponent<Weapon>();
        Weapon weapon2 = new GameObject().AddComponent<Weapon>();
        Weapon comboWeapon = new GameObject().AddComponent<Weapon>();
        gameManager.comboWeapon.Add("weapon1", comboWeapon);

        gameManager.playerWeapons_upgradeable = new List<Weapon> { weapon1 };
        gameManager.playerWeapons = new List<Weapon> { weapon1, weapon2 };

        gameManager.ComboWeapons(0);

        Assert.AreEqual(1, gameManager.playerWeapons.Count);
        Assert.AreEqual(comboWeapon, gameManager.playerWeapons[0]);
        Assert.AreEqual(1, gameManager.playerWeapons[0].coolDown.fillAmount);
        Assert.AreEqual(1, gameManager.playerWeapons[0].GetLevel());
    }
*/
    [Test]
    public void UpgradeWeaponTest()
    {
        TEST_GameManager gameManager = new GameObject().AddComponent<TEST_GameManager>();

        Weapon weapon = new GameObject().AddComponent<Weapon>();
        gameManager.playerWeapons_upgradeable = new List<Weapon> { weapon };

        gameManager.UpgradeWeapon(0);

        Assert.AreEqual(2, weapon.GetLevel());
        Assert.AreEqual(1, gameManager.playerWeapons_upgradeable.Count);
    }

/*    [Test]
    public void TestAddWeapon()
    {
        TEST_GameManager gameManager = new GameObject().AddComponent<TEST_GameManager>();

        Weapon weapon = new GameObject().AddComponent<Weapon>();
        gameManager.weaponList = new List<Weapon> { weapon };
        gameManager.playerWeapons = new List<Weapon>();

        gameManager.AddWeapon(0);

        Assert.AreEqual(1, gameManager.playerWeapons.Count);
        Assert.AreEqual(weapon, gameManager.playerWeapons[0]);
        Assert.AreEqual(1, gameManager.playerWeapons[0].coolDown.fillAmount);
        Assert.AreEqual(1, gameManager.playerWeapons[0].GetLevel());
    }*/
}
