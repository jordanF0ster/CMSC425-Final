using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMeleeEnemies : MonoBehaviour
{
    public Enemy[] enemiesToSpawn; // all enemies to be spawned in a room
    public Player player; // target
    Enemy[] enemies; // house all enmies
    int numEnemies; // num enemies total
    public int[] numEnemiesType; // array of num enemies per type
    float x;
    float y;
    float z;
    Vector3 pos;
    int xSpawnWidth = 15;

    // Start is called before the first frame update
    void Start()
    {
        // here is where the player and enemies for the room are generated

        foreach (int x in numEnemiesType)
            numEnemies += x;

        enemies = new Enemy[numEnemies];

        if (player != null)
        {
            Player playerGo = Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
            MoveCamera cam = Camera.main.GetComponent<MoveCamera>();
            cam.target = playerGo;
            cam.dist = cam.transform.position - player.getPos();

            float xMin = transform.position.x - xSpawnWidth;
            float xMax = transform.position.x + xSpawnWidth;
            float zMin = transform.position.z + 20;
            float zMax = transform.position.z + 35;
            spawnEnemies(enemiesToSpawn, numEnemiesType, xMin, xMax, zMin, zMax, playerGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfAllMarked())
        {
            foreach (Enemy e in enemies)
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

        foreach (Enemy enemy in enemies)
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

    // here we instantiate num number of enemies in a random position that fits within [xMinRange,xMaxRange] and [zMinRange, zMaxRange] inclusively
    public void spawnEnemyType(Enemy toSpawn, int num, float xMinRange, float xMaxRange, float zMinRange, float zMaxRange, Player target, int lstStartPos)
    {
        //enemies = new Enemy[num];
        for (int i = 0; i < num; i++)
        {
            // NOTE: this assumes that it faces along the Z axis, if rotated then need to change
            // as a result all rooms should be aligned facing positive z axis
            x = Random.Range(xMinRange, xMaxRange);
            y = 1;
            z = Random.Range(zMinRange, zMaxRange);
            pos = new Vector3(x, y, z);
            Enemy enemy = Instantiate(toSpawn, pos, Quaternion.identity);
            enemy.player = target;
            enemies[lstStartPos] = enemy;
            lstStartPos++;
        }
    }

    // spawns num number of enemies from enemies array
    public void spawnEnemies(Enemy[] enemiesLst, int[] num, float xMinRange, float xMaxRange, float zMinRange, float zMaxRange, Player target)
    {
        if (enemiesLst.Length != num.Length)
            return;

        int lstStartPos = 0;
        for (int i = 0; i < enemiesLst.Length; i++)
        {
            spawnEnemyType(enemiesLst[i], num[i], xMinRange, xMaxRange, zMinRange, zMaxRange, target, lstStartPos);
            lstStartPos += num[i];
        }
    }
}
