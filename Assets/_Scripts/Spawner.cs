using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]

    public GameObject objPrefab;
    public GameObject spawnPos;

    public List<GameObject> objects;

    public float spawnTimer = 0f;
    public float spawnDelay = 1f;

    public string spawnPosName = "";
    public string prefabName = "";

    public int maxObject = 1;

    private void Awake()
    {
        this.objects = new List<GameObject>();
        this.spawnPos = GameObject.Find(this.spawnPosName);
        this.objPrefab = GameObject.Find(this.prefabName);
        this.objPrefab.SetActive(false);
    }

    private void Update()
    {
        this.Spawn();
        this.CheckDead();
    }

    protected virtual GameObject Spawn() {
        if (PlayerController.instance.damageReceiver.IsDead()) return null;
        if (this.objects.Count >= this.maxObject) return null;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return null;
        this.spawnTimer = 0;

        Vector3 pos = this.spawnPos.transform.position;
        return this.Spawn(pos);
    }

    protected virtual GameObject Spawn(Vector3 vector)
    {
        GameObject obj = Instantiate(this.objPrefab);
        obj.transform.position = vector;
        obj.transform.parent = transform;
        obj.SetActive(true);

        this.objects.Add(obj);

        return obj;
    }

    protected virtual void CheckDead()
    {
        GameObject obj;
        for (int i = 0; i < this.objects.Count; i++)
        {
            obj = this.objects[i];
            if (obj == null) this.objects.RemoveAt(i);
        }
    }
}
