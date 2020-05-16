using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    int randomPoint;
    public bool permitido;
    private void Start() {
        permitido = true;
        InvokeRepeating("SpawnAMonster",0f,3f);
    }

    void SpawnAMonster()
    {
        if(permitido)
        {
            randomPoint = Random.Range(0,spawnPoints.Length);
            GameObject clone = (GameObject)Instantiate(enemyPrefab,spawnPoints[randomPoint].position, Quaternion.identity);
            float randomScale = Random.Range(0.14f,0.27f);
            clone.transform.localScale = new Vector3 (randomScale,randomScale,0);
            Destroy(clone,10f);
        }
    }
}