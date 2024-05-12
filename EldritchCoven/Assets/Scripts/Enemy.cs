using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public FieldOfView fov;
    public GameObject player;
    public float attackRange = 4f;
    public GameObject enemyCollider;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject;
    }

    public bool PlayerInAttackRange()
    {
        return Vector3.Distance(GameLogic.instance.playerController.transform.position, this.transform.position) < attackRange;
    }
}
