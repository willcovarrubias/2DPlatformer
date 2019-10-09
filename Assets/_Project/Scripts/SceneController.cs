using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    GameMaster gameMaster;
    CharacterDatabase characterDatabase;

    public GameObject playerToSpawn;
    public Transform playerSpawnPosition;

    void Start()
    {
        gameMaster = GetComponent<GameMaster>();
        characterDatabase = GetComponent<CharacterDatabase>();
    }

    void SpawnPlayer()
    {
        Instantiate(playerToSpawn, playerSpawnPosition.position, playerSpawnPosition.rotation);
    }

    void SetPlayerStats()
    {

    }
}
