using System.Collections.Generic;
using UnityEngine;

public class FocusTower : MonoBehaviour, ITowerBehavior
{
    [SerializeField]
    private GameObject _BulletPrefab;

    public GameObject BulletPrefab { get => _BulletPrefab; set => _BulletPrefab = value; }
    public float BulletDamage { get; set; } = 0.5F;
    public float BulletSpeed { get; set; } = 0.01F;//0.1F;
    public float CooldownMax { get; set; } = 0.2F;
    public float Cooldown { get; set; } = 0;
    public float Range { get; set; } = 5;

    public void FireBullet(GameObject target)
    {
        Cooldown = CooldownMax;
        var newBullet = Instantiate(BulletPrefab, transform.position, new Quaternion(), transform);
        var bulletBehavior = newBullet.GetComponent<IBulletBehavior>();
        bulletBehavior.SetBulletParams(target, BulletDamage, BulletSpeed);
    }
}
