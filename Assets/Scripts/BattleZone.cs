using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleZone : MonoBehaviour
{
    public GameObject enemy;
    public GameObject toHide;
    public GameObject toShow;
    public GameObject player;
    public Transform playerPosition;
    public Button attackButton;
    private GameManager gameManager;
    private Rigidbody enemyRigidBody;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyRigidBody = enemy.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        gameManager.EnableBattleMode(this);
        enemyRigidBody.constraints =RigidbodyConstraints.FreezeRotation;
        enemy.GetComponent<Health>().resetHealthBar();
        attackButton.onClick.RemoveAllListeners();
        attackButton.onClick.AddListener(() => gameManager.GetComponent<BattleManager>().Attack());
        attackButton.onClick.AddListener(() => enemy.GetComponent<EnemyController>().GetEmotionalDamage());
        GetComponent<CapsuleCollider>().enabled = false;
        toHide.SetActive(false);
        toShow.SetActive(true);

        player.transform.position = playerPosition.position;
        player.transform.rotation = playerPosition.rotation;

        player.GetComponent<Animator>()?.SetTrigger("StartBattle");
        if (Random.Range(0, 2) == 0)
            enemy.GetComponent<Animator>()?.SetTrigger("FightPose1");
        else
            enemy.GetComponent<Animator>()?.SetTrigger("FightPose2");

    }
}
