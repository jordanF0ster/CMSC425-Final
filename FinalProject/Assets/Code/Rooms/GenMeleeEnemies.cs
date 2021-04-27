using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeleeEnemies : MonoBehaviour
{
    public MoveToPlayer enemyToSpawn;
    public Player player;
    MoveToPlayer[] enemies;
    int numEnemies = 5;
    float x;
    float y;
    float z;
    Vector3 pos;
    int xSpawnWidth = 15;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new MoveToPlayer[numEnemies];
        Player playerGo = Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
        //Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
        float xMin = transform.position.x - xSpawnWidth;
        float xMax = transform.position.x + xSpawnWidth;
        float zMin = transform.position.z + 20;
        float zMax = transform.position.z + 35;
        spawnEnemies(numEnemies, xMin, xMax, zMin, zMax, playerGo);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfAllMarked())
        {
            foreach (MoveToPlayer e in enemies)
            {
                if (e != null)
                    Destroy(e.gameObject);
            }
        }
    }

    public bool checkIfAllMarked()
    {
        if (enemies.Length == 0)
            return false;

        foreach (MoveToPlayer enemy in enemies)
        {
            if (enemy != null)
            {
                Enemy e = enemy.GetComponent<Enemy>();
                if (e == null || !e.isMarked())
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void spawnEnemies(int num, float xMinRange, float xMaxRange, float zMinRange, float zMaxRange, Player target)
    {
        enemies = new MoveToPlayer[num];
        for (int i = 0; i < num; i++)
        {
            // NOTE: this assumes that it faces along the Z axis, if rotated then need to change
            // as a result all rooms should be aligned facing positive z axis
            x = Random.Range(xMinRange, xMaxRange);
            y = 2;
            z = Random.Range(zMinRange, zMaxRange);
            pos = new Vector3(x, y, z);
            MoveToPlayer enemy = Instantiate(enemyToSpawn, pos, Quaternion.identity);
            //enemy.transform.parent = this.transform;
            //enemy.transform.position = pos;
            enemy.player = target;
            enemies[i] = enemy;
        }
    }
}
