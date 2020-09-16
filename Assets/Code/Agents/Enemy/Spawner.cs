using UnityEngine;
using System.Collections;
using TowerDefense.Managers;

namespace TowerDefense.Enemies
{
    public class Spawner : MonoBehaviour
    {
        public float SpawnRate { get; private set; } = 1f;

        float currentTime;
        EnemyManager enemyM;

        void Start()
        {
            enemyM = EnemyManager.instance;
        }

        void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (currentTime < SpawnRate)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0f;
                if (enemyM != null)
                {
                    enemyM.SpawnEnemy(transform);
                }
            }
        }
    }
}