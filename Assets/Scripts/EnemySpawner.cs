using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Path;
    private float Cooldown = 2;
    private readonly float CooldownMax = 0.8F;
    private int SpawnAmount = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown -= Time.deltaTime;
        if (Cooldown <= 0)
        {
            var enemy = Instantiate(Enemy, this.transform.position, new Quaternion());
            enemy.GetComponent<EnemyMovement>().Path = Path;
            SpawnAmount--;
            if (SpawnAmount <= 0)
            {
                Destroy(this.gameObject);
            }
            Cooldown = CooldownMax;
        }
    }
}
