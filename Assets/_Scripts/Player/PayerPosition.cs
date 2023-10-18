using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private float playerPosX;
    List<GameObject> minions;
    public GameObject minionPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 0f;

    void Start()
    {
        this.minions = new List<GameObject>();
    }

    void NotSpawn()
    {
        Debug.Log("Not Spawned");
    }

    void Spawn()
    {
        this.spawnTimer += Time.deltaTime;

        if(this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;

        if(this.minions.Count >= 7) return;

        int index = this.minions.Count + 1;
        GameObject minion = Instantiate(this.minionPrefab);
        minion.name = "BomPrefab #" + index;

        minion.transform.position = transform.position;

        minion.gameObject.SetActive(true);

        this.minions.Add(minion);
    }

    void CheckMinionDead()
    {
        GameObject minion;
        for(int i = 0; i < this.minions.Count; i++)
        {
            minion = this.minions[i];
            if(minion == null) this.minions.RemoveAt(i);
        }
    }
    
    void Update()
    {
        this.playerPosX = transform.position.x;
        
        this.Spawn();

        this.CheckMinionDead();
    }
}
