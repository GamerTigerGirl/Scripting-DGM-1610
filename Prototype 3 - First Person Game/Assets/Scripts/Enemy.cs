using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // Enemy Stats
    public int curHP, maxHP, scoreToGive;
    //Movement
    public float moveSpeed, attackRange, yPathOffset;
    // Coordinates for a path
    private List<Vector3> path;
    // Enemy Weaopn
    private Weapon weapon;
    // Target to follow
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        //Get the Componets
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHP = maxHP;
    }

    void UpdatePath()
    {
        //Calculate a path to the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        //Move towards the closet path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    //Applies Damage to the Enemy
    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Die();
    }

    //If enemy health is zero they are destroyed
    void Die()
    {
        GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }

    void Update()
    {
        //Look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        //Calulate the distance between the enemy and the player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        //If within attackerange shoot at player
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        //If enemy is too far away chase after player
        else
        {
            ChaseTarget();
        }
    
    }

}
