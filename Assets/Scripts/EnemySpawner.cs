using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Stack<GameObject> EnemyStack = new Stack<GameObject>();
    public GameObject Path;
    private float Cooldown = 30;
    private readonly float CooldownMax = 300;
    private int SpawnAmount = 10;

    public void StartNextWave()
    {
        for (int i = 0; i <= SpawnAmount; i++)
        {
            EnemyStack.Push(Enemy);
        }
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown--;
        if (Cooldown <= 0)
        {
            var enemy = Instantiate(EnemyStack.Pop(), this.transform.position, new Quaternion());
            enemy.GetComponent<EnemyMovement>().Path = Path;
            if (EnemyStack.Count <= 0)
            {
                gameObject.SetActive(false);
            }
            Cooldown = CooldownMax;
        }
    }
}
