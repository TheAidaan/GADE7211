using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public static Spawner instance;

    GameObject[] NPCs= new GameObject[5];
    /*[0] = Circle
      [1] = Hexagon
      [2] = Square
      [3] = Trapezuim
      [4] Triangle
    */

    Transform[] _points;
    /*[0] = Self
      [1-4] = Random SpawnPoint
      [5] = NPC "folder"
    */

    int _numberOfNPCs;
    bool _spawning;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _numberOfNPCs = 0;
        _points = GetComponentsInChildren<Transform>();

        NPCs = Resources.LoadAll<GameObject>("Prefabs/NPCS");
    }

    // Update is called once per frame
    void Update()
    {
        if (_numberOfNPCs<50 && !_spawning)
        {
            StartCoroutine(Spawn());
        }
        
    }

    IEnumerator Spawn()
    {
        _spawning = true;
        int randSpawnIndex = Random.Range(1, 5);
        int randNPC = Random.Range(1, 5);
        GameObject npc = Instantiate(NPCs[randNPC], _points[randSpawnIndex].position, Quaternion.identity, _points[5]);
        int randTargetIndex = Random.Range(1, 5);

        while (randSpawnIndex == randTargetIndex)
        {
            randTargetIndex = Random.Range(1, 5);
        }

        npc.GetComponent<NPCController>().AssignTarget(_points[randTargetIndex].position);
        _numberOfNPCs++;

        yield return new WaitForSeconds(2);
        _spawning = false;
    }
    void DecreaseNumeberOFNPCs()
    {
        _numberOfNPCs--;
    }

    public static void Static_DecreaseNumeberOFNPCs()
    {
        instance.DecreaseNumeberOFNPCs();
    }
}
