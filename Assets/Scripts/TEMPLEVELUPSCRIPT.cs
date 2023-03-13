// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TEMPLEVELUPSCRIPT : MonoBehaviour
// {
//     // IN PLAYER
//     if (experience >= xpToLevelUp) {
//         LevelUp();
//         xpToLevelUp += 50f; // Change?
//         experience = 0;
//     }

//     void LevelUp() {
//         level += 1;

//         switch (level) {
//             case 1:
//                 // Increase Damage/Health/Whatever
//                 break;
//         }

//         LevelUpRoll();
//     }

//     // IN GAME MANAGER
//     public void LevelUpRoll() {
//         // Spawn UI
//         int options = new int[] {Random.Range(1, 4), Random.Range(1, 4), Random.Radius(1, 4)};

//         // Check if any more new weapons/items, and check if player even has items
//         // Also check if the item can even be upgraded.
//         // Maybe have a list of "upgradeable" items

//         for (int i = 0; i < 3; i++) {
//             switch (options[i]) {
//                 case 1: 
//                     UI.option[i] = RollNewItem();
//                     break;
//                 case 2:
//                     UI.option[i] = RollNewWeapon();
//                     break;
//                 case 3:
//                     UI.option[i] = RollUpgradeItem();
//                     break;
//                 case 4:
//                     UI.option[i] = RollUpgradeWeapon();
//                     break;
//             }
//         }
//     }

//     void RollNewItem() {
//         return itemList[Random.Range(0, itemList.Count)]; // Assuming that when the item is chosen, it is completely removed from the list and the list is updated to reflect the lesser elements. If not, add incrementing index check
//     }

//     void RollNewWeapon() {
//         return weaponList[Random.Range(0, weaponList.Count)];
//     }

//     void RollUpgradeItem() {
//         return player.items[Random.Range(0, player.items.Count)];
//     }

//     void RollUpgradeWeapon() {
//         return player.weapons[Random.Range(0, player.weapons.Count)];
//     }

//     // Make Items spawn in, and on start, empart their effects?
//     // When destroyed, undo changes
// }
