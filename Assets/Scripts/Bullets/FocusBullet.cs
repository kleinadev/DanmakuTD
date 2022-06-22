using UnityEngine;

public class FocusBullet : MonoBehaviour, IBulletBehavior
{
    private float Speed;
    private GameObject Target;
    private Vector2 Direction;
    private float Damage;

    public float GetDamage()
    {
        return this.Damage;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }

    public void SetBulletParams(GameObject target, float damage, float speed)
    {
        SetTarget(target);
        SetDamage(damage);
        SetSpeed(speed);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Target)
        {
            Direction = (Target.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed);
        }
        else
        {
            transform.Translate(Direction * Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
