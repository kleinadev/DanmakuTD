using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadBullet : MonoBehaviour, IBulletBehavior
{
    private float Speed;

    /// <summary>
    /// Normalized vector for the direction the bullet will travel
    /// </summary>
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
        var direction = target.transform.position - transform.position;
        direction.Normalize();
        Direction = direction;
    }

    public void SetBulletParams(GameObject target, float damage, float speed)
    {
        SetSpeed(speed);
        SetTarget(target);
        SetDamage(damage);
    }

    public void SetAngle(float angle)
    {
        var direction = Vector3.Distance(transform.position, Direction);
        var perpendicularVector = new Vector2(-Direction.y, Direction.x);
        float angleScalar = GetVectorMagnitudeFromAngle(angle);
        perpendicularVector = perpendicularVector.normalized * angleScalar;
        Direction = (Direction + perpendicularVector).normalized;
    }

    private float GetVectorMagnitudeFromAngle(float angle)
    {
        return Mathf.Tan(angle * Mathf.Deg2Rad);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Direction * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
