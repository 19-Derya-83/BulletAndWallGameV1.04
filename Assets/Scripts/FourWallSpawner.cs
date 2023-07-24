using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class FourWallSpawner : MonoBehaviour
    {

        public GameObject[] walls;

        public Vector3 spawnPoint;

        private void Start()
        {

            SpawnWall();

        }

        private void SpawnWall()

        {

            Instantiate(walls[Random.Range(0, walls.Length)], spawnPoint + Vector3.right * Random.Range(-10, 10), 
                Quaternion.identity);

        }

    }


