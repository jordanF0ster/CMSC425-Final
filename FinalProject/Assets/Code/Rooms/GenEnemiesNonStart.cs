using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnemiesNonStart : MonoBehaviour
{
    public Enemy enemyToSpawn;
    public Player player;
    Enemy[] enemies;
    public int numEnemies = 5;
    float x;
    float y;
    float z;
    Vector3 pos;
    int xSpawnWidth = 15;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new Enemy[numEnemies];
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfAllMarked()) {
            foreach(Enemy e in enemies) {
                if (e != null) {
                    Destroy(e.gameObject);
                }
            }
        }
    }
    private void onTriggerEnter(Collider other) {
        Debug.Log("Collsion detected");
        if (other.gameObject.tag == "PlayerGo") {
            if (player != null) {
                float xMin = transform.position.x - xSpawnWidth;
                float xMax = transform.position.x + xSpawnWidth;
                float zMin = transform.position.z + 2;
                float zMax = transform.position.z + 3.5f;
                spawnEnemies(numEnemies, xMin, xMax, zMin, zMax, player);
            }
        }
    }
    public bool checkIfAllMarked() {
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

    public void spawnEnemies(int num, float xMinRange, float xMaxRange, float zMinRange, float zMaxRange, Player target)
    {
        enemies = new Enemy[num];
        for (int i = 0; i < num; i++)
        {
            // NOTE: this assumes that it faces along the Z axis, if rotated then need to change
            // as a result all rooms should be aligned facing positive z axis
            x = Random.Range(xMinRange, xMaxRange);
            y = 1;
            z = Random.Range(zMinRange, zMaxRange);
            pos = new Vector3(x, y, z);
            Enemy enemy = Instantiate(enemyToSpawn, pos, Quaternion.identity);
            enemy.player = target;
            enemies[i] = enemy;
        }
    }
}
