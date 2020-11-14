using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Target;
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
    void Start()
    {
        _points = GetComponentsInChildren<Transform>();

        NPCs = Resources.LoadAll<GameObject>("Prefabs/NPCS");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int randLocation = Random.Range(1, 3);
            int randNPC = Random.Range(1, 5);
            GameObject npc = Instantiate(NPCs[randNPC], _points[randLocation].position, Quaternion.identity, _points[5]);
            npc.GetComponent<NPCController>().AssignTarget(Target);
        }
        
    }
}
