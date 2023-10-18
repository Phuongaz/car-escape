using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    protected GameObject roadPrefab;
    protected GameObject roadSpawnPos;

    protected float distance = 0;

    protected GameObject currentRoad;

    private void Awake()
    {
        this.roadPrefab = GameObject.Find("RoadPrefab");
        this.roadSpawnPos = GameObject.Find("RoadSpawnPos");

        this.roadPrefab.SetActive(false);

        this.currentRoad = this.roadPrefab;
        this.Spawn(this.roadPrefab.transform.position);
    }

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        this.distance = Vector2.Distance(PlayerController.instance.transform.position, this.currentRoad.transform.position);
        if (this.distance > 40) this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 pos = this.roadSpawnPos.transform.position;
        pos.x = 0;

        this.Spawn(pos);
    }

    protected virtual void Spawn(Vector3 position)
    {
        this.currentRoad = Instantiate(this.roadPrefab, position, this.roadPrefab.transform.rotation);
        this.currentRoad.transform.parent = transform;
        this.currentRoad.SetActive(true);
    }
}
