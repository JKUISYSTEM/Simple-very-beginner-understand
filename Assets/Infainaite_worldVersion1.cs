using UnityEngine;
using System.Collections.Generic;

public class Infainaite_worldVersion1 : MonoBehaviour
{
    public GameObject terrain1;
    public GameObject TriggerZoneDup;
    public Transform location;
    public int ReducerOfUnit=50;

    public int TerrainLength = 100;

    private int locationChange = 100;

    private Queue<GameObject> terrains =
        new Queue<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Vector3 spawnPos =
            new Vector3(
                location.position.x - locationChange,
                location.position.y,
                location.position.z
            );

        GameObject newTerrain =
            Instantiate(
                terrain1,
                spawnPos,
                Quaternion.identity
            );

        terrains.Enqueue(newTerrain);

        if (terrains.Count > 2)
        {
            Destroy(terrains.Dequeue());
        }

        TriggerZoneDup.transform.position =
            new Vector3(
                TriggerZoneDup.transform.position.x - (TerrainLength-ReducerOfUnit),
                TriggerZoneDup.transform.position.y,
                TriggerZoneDup.transform.position.z
            );

        locationChange += TerrainLength;

        Debug.Log($"Spawned Terrain At {spawnPos}");
    }
}