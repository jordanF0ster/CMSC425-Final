using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBossRoom : MonoBehaviour
{

    public BossEnemy boss;
    int phase = 0; // what phase we are in for the boss fight
    public int maxPhases = 3; // how many times will the player repeat the boss fight;

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
    bool spawn = true;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    //float x;
    //float y;
    //float z;

    // Start is called before the first frame update
    void Start()
    {
        foreach (int x in numEnemiesType)
            numEnemies += x;

        enemies = new Enemy[numEnemies];
        Debug.Log("NUM: " + numEnemiesType[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase < maxPhases && checkIfAllMarked())
        {
            boss.unMark();
            foreach (Enemy e in enemies)
            {
                if (e != null)
                    Destroy(e.gameObject);
            }

            //boss.unMark();
            phase += 1;
            spawnNextPhase();
        }
        else if (phase == maxPhases)
        {
            foreach (Enemy e in enemies)
            {
                if (e != null)
                    Destroy(e.gameObject);
            }
            if (boss != null)
                Destroy(boss.gameObject);
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

        return boss.isMarked();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject != null && other.gameObject.tag == "PlayerGo")
        {
            player = other.gameObject.GetComponent<Player>();
        }


        //Debug.Log("Collsion detectedVVVVV");

        if (spawn && player != null)
        {
            spawnEnemies(enemiesToSpawn, numEnemiesType, xMin, xMax, zMin, zMax, player);

            x = Random.Range(xMin, xMax);
            y = 2;
            z = Random.Range(zMin, zMax);
            pos = new Vector3(x, y, z);
            boss = Instantiate(boss, pos, Quaternion.identity);
            boss.player = player;

            spawn = false;
        }
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

    // spawns next phase of enemies
    public void spawnNextPhase()
    {
        spawnEnemies(enemiesToSpawn, numEnemiesType, xMin, xMax, zMin, zMax, player);
    }
}
