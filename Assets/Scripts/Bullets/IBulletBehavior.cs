using UnityEngine;

public interface IBulletBehavior
{
    float GetDamage();
    void SetDamage(float damage);

    void SetSpeed(float speed);
    void SetTarget(GameObject target);

    void SetBulletParams(GameObject target, float damage, float speed);
}
