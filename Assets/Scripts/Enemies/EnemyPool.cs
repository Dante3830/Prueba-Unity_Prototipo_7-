using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> enemyList;

    private static EnemyPool instance;
    public static EnemyPool Instance { get { return instance; } }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        AddEnemiesToPool(poolSize);
    }

    private void AddEnemiesToPool(int amount) {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy1 = Instantiate(enemyPrefab1);
            GameObject enemy2 = Instantiate(enemyPrefab2);
            enemy1.SetActive(false);
            enemy2.SetActive(false);
            enemyList.Add(enemy1);
            enemyList.Add(enemy2);
            enemy1.transform.parent = transform;
            enemy2.transform.parent = transform;
        }
    }

    public GameObject RequestEnemies() {
        for (int i = 0; i < enemyList.Count; i++) {
            if (!enemyList[i].activeSelf) {
                enemyList[i].SetActive(true);
                return enemyList[i];
            }
        }

        return null;
    }

}
