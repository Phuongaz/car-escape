using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner
{
    private void Reset()
    {
        this.spawnPosName = "BombSpawnPos";
        this.prefabName = "BombPrefab";
        this.maxObject = 7;
    }
}
