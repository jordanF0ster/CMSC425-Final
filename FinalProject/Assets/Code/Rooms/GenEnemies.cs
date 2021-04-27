using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenEnemies : MonoBehaviour
{
    public MoveToPlayer enemyToSpawn;
    public Player player;
    MoveToPlayer[] enemies;
    int numEnemies = 5;
    float x;
    float y;
    float z;
    Vector3 pos;
    int xSpawnWidth = 20;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new MoveToPlayer[numEnemies];
        Player playerGo = Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
        //Instantiate(player, new Vector3(0, 2, 0), Quaternion.identity);
        for (int i = 0; i < numEnemies; i++)
        {
            // NOTE: this assumes that it faces along the Z axis, if rotated then need to change
            // as a result all rooms should be aligned facing positive z axis
            x = Random.Range(transform.position.x - xSpawnWidth, transform.position.x + xSpawnWidth);
            y = 2;
            z = Random.Range(transform.position.z + 20, transform.position.z + 35);
            pos = new Vector3(x, y, z);
            MoveToPlayer enemy = Instantiate(enemyToSpawn, pos, Quaternion.identity);
            //enemy.transform.parent = this.transform;
            //enemy.transform.position = pos;
            enemy.player = playerGo;
            enemies[i] = enemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfAllMarked())
        {
            foreach (MoveToPlayer e in enemies)
            {
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
            Enemy e = enemy.GetComponent<Enemy>();
            if (e == null || !e.isMarked())
            {
                return false;
            }
        }

        return true;
    }
}
