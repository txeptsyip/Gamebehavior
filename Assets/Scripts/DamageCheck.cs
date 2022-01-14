using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCheck : MonoBehaviour
{
    public static DamageCheck instance;

    public List<Damageobj> obsinspace = new List<Damageobj>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        for (int a = 0; a < obsinspace.Count; a++)
        {
            for (int b = 0; b < obsinspace.Count; b++)
            {
                if (a != b)
                {
                    var current = obsinspace[a];
                    var other = obsinspace[b];
                    if (current.damageObj.isBullet == true && other.damageObj.isBullet == true)
                    {
                        break;
                    }
                    else if (current.damageObj.isEBullet == true && other.damageObj.isEBullet == true)
                    {
                        break;
                    }
                    else if (current.damageObj.isplayer== true && other.damageObj.isBullet == true)
                    {
                        break;
                    }
                    else if (current.damageObj.isEnemy == true && other.damageObj.isEBullet == true)
                    {
                        break;
                    }
                    else
                    {
                        dmgcolliding(current.damageObj, other.damageObj);
                    }
                }
            }
        }
    }
    void dmgcolliding(damageobj shapeA, damageobj shapeB)
    {
        if (shapeA.xmax > shapeB.xmin && shapeA.xmin < shapeB.xmax && shapeA.ymax > shapeB.ymin && shapeA.ymin < shapeB.ymax)
        {
            shapeA.Health = shapeA.Health - shapeB.damage;
            shapeB.Health = shapeB.Health - shapeA.damage;
        }
    }
}

[System.Serializable]
public class damageobj
{
    public Vector3 velocity;
    public Vector3 position;
    public float xmax = 1f;
    public float xmin = 1f;
    public float ymax = 1f;
    public float ymin = 1f;
    public float width = 1f;
    public float height = 1f;
    public float Health;
    public float damage;
    public bool isBullet;
    public bool isEnemy;
    public bool isEBullet;
    public bool isplayer;
    public bool istargeted;
}