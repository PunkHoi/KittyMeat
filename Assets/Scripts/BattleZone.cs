using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZone : MonoBehaviour
{
    public GameObject enemy;
    public GameObject toHide;
    public GameObject toShow;
    public GameObject player;
    public Transform playerPosition;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        gameManager.EnableBattleMode(this);

        GetComponent<CapsuleCollider>().enabled = false;
        toHide.SetActive(false);
        toShow.SetActive(true);

        player.transform.position = playerPosition.position;
        player.transform.rotation = playerPosition.rotation;

        player.GetComponent<Animator>()?.SetTrigger("StartBattle");
        enemy.GetComponent<Animator>()?.SetTrigger("FightPose1");
    }
}
