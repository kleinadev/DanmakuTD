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
    private Vector3 Direction;
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

    public void SetAngle(double angle)
    {
        var direction = Vector3.Distance(transform.position, Direction);
        var perpendicularVector = new Vector3(-Direction.y, Direction.x);
        float angleScalar = GetVectorMagnitudeFromAngle(angle);
        perpendicularVector = perpendicularVector.normalized * angleScalar;
        Direction = (Direction + perpendicularVector).normalized;
    }

    private float GetVectorMagnitudeFromAngle(double angle)
    {
        var radianAngle = angle * (Math.PI / 180);
        return (float)Math.Tan(radianAngle);
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
