using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadTower : MonoBehaviour, ITowerBehavior
{
    [SerializeField]
    private GameObject _BulletPrefab;

    public GameObject BulletPrefab { get => _BulletPrefab; set => _BulletPrefab = value; }
    public float BulletDamage { get; set; } = 0.5F;
    public float BulletSpeed { get; set; } = 0.02F;
    public float CooldownMax { get; set; } = 0.4F;
    public float Cooldown { get; set; } = 0;
    public float Range { get; set; } = 5;

    private int ExtraBullets = 2;

    public void FireBullet(GameObject target)
    {
        Cooldown = CooldownMax;
        FireSpreadBullets(target);
    }

    private void FireSpreadBullets(GameObject target)
    {
        for (int i = -ExtraBullets; i <= ExtraBullets; i++)
        {
            var bullet = CreateSpreadBullet(target);

            if (bullet.GetType() == typeof(SpreadBullet))
            {
                SpreadBullet spreadBullet = (SpreadBullet)bullet;
                spreadBullet.SetAngle(i * 15);
            }
        }
    }

    private IBulletBehavior CreateSpreadBullet(GameObject target)
    {
        var newBullet = Instantiate(BulletPrefab, transform.position, new Quaternion(), transform);
        var bulletBehavior = newBullet.GetComponent<IBulletBehavior>();
        bulletBehavior.SetBulletParams(target, BulletDamage, BulletSpeed);
        return bulletBehavior;
    }
}
