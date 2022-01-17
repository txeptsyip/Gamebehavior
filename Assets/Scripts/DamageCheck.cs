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
                var current = obsinspace[a];
                var other = obsinspace[b];
                if (a == b)
                {
                    break;
                }
                // ok so if i do a check to make sure the player cannot fucking kill themselves (current + other isplayer == true and other + current isbullet == true) then the ENEMY stop taking bullet dmg despite no check for that happening
                // god this code is cursed I should have just modified my existing phyics to... i dunno output that a collision happened if something wants that (look into how unity oncollide or w/e its called works?)
                // too late now though I don't even have a battlecow implemented
                else if (current.damageObj.isBullet == true && other.damageObj.isBullet == true)
                {
                    break;
                }
                else if (current.damageObj.isEBullet == true && other.damageObj.isEBullet == true)
                {
                    break;
                }
                else if (current.damageObj.isplayer == true && other.damageObj.isBullet == true)
                {
                    break;
                }
                else if (current.damageObj.isEnemy == true && other.damageObj.isEBullet == true)
                {
                    break;
                }
                else 
                {
                    //var current = obsinspace[a];
                    //var other = obsinspace[b];
                    //if (current.damageObj.isBullet == true && other.damageObj.isBullet == true)
                    //{
                    //    break;
                    //}
                    //else if (current.damageObj.isEBullet == true && other.damageObj.isEBullet == true)
                    //{
                    //    break;
                    //}
                    //else if (current.damageObj.isplayer== true && other.damageObj.isBullet == true)
                    //{
                    //    break;
                    //}
                    //else if (current.damageObj.isEnemy == true && other.damageObj.isEBullet == true)
                    //{
                    //    break;
                    //}
                    // so those else ifs are there to try and make sure that theres no friendly fire or bullets destroying bullets - it ain't working though
                    // figured it out I forgot I was using other and current and I would need to check against other and current then current and other, I wonder if there is a way
                    // to just go "hey if either of these have a bool called X and is true don't do this" but NO TIME
                    //else
                    //{
                        dmgcolliding(current.damageObj, other.damageObj);
                    //}
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
    public bool isBullet = false;
    public bool isEnemy = false;
    public bool isEBullet = false;
    public bool isplayer = false;
    public bool istargeted = false;
}