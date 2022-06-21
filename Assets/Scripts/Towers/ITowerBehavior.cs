using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerBehavior
{
    GameObject BulletPrefab { get; set; }
    float Range { get; set; }
    float BulletDamage { get; set; }
    float BulletSpeed { get; set; }
    float Cooldown { get; set; }
    float CooldownMax { get; set; }

    void FireBullet(GameObject target);
}
