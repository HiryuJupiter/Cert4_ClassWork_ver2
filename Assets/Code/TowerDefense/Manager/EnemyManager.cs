using UnityEngine;
using System.Collections;
using Boo.Lang;
using TowerDefense.Enemies;

namespace TowerDefense.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;

        [SerializeField]
        GameObject enemyPrefab;

        List<Enemy> aliveEnemies = new List<Enemy>();

        public void SpawnEnemy(Transform spawnPoint)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, enemyPrefab.transform.rotation);
            aliveEnemies.Add(newEnemy.GetComponent<Enemy>());
        }

        /// <summary>
        /// Loops through all enemie alive in the game, finding the closest enemies within a certain range.
        /// </summary>
        /// <param name="target">The object we are comparing</param>
        /// <param name="maxRange">The range we are finding enemies within</param>
        /// <param name="minRange">The range the enemies must at least be from the target</param>
        /// <returns>The list of enemies within the given range.</returns>
        public Enemy[] GetClosestEnemies (Transform target, float maxRange, float minRange = 0f)
        {
            List<Enemy> closeEnemies = new List<Enemy>();

            foreach (Enemy enemy in aliveEnemies)
            {
                float distance = Vector3.Distance(enemy.transform.position, target.transform.position);
                if (distance > minRange && distance < maxRange)
                {
                    closeEnemies.Add(enemy);
                }
            }

            return closeEnemies.ToArray();
        }

        private void Awake()
        {
           if (instance == null)
            {
                instance = this;
            }
           else if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}