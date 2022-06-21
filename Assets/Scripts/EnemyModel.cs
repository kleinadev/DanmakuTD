using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public float MoveSpeed;
    private float maxHP;
    private float curHP;

    // Start is called before the first frame update
    private void Start()
    {
        maxHP = 6;
        curHP = maxHP;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            this.curHP -= (collision.gameObject.GetComponent<IBulletBehavior>()).GetDamage();
            if (this.curHP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}