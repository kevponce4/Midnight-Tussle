﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Reinforcement")]
public class Reinforcement : Ability
{
    public GameObject dogMinionPrefab;
    public GameObject catMinionPrefab;

    public const int MINIONHP = 2;
    public const int MINIONDMG = 2;
    public const int MINIONSPEED = 1;

    public override void TriggerAbility(Unit unit) {
        Unit minion;
        if (unit.playertype == PlayerType.DOG) {
            minion = Instantiate(dogMinionPrefab).GetComponent<Unit>();
            minion.playertype = PlayerType.DOG;
        }
        else {
            minion = Instantiate(catMinionPrefab).GetComponent<Unit>();
            minion.playertype = PlayerType.CAT;
        }

        Tile tile = unit.occupiedTile;
        tile.ClearUnit();
        TussleManager.instance.PlaceMinion(minion, tile, unit.player);

        minion.initialHealth = MINIONHP;
        minion.attack = MINIONDMG;
        minion.movement = MINIONSPEED;

        minion.movementLeft = 0;

        minion.health = MINIONHP;
        minion.RecalculateDepth();
    }
}
