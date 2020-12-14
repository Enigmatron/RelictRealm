using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public abstract partial class Entity : MonoBehaviour
{
    public enum EntityStats
    {
        Health,
        Movespeed,
        JumpSpeed,
        Shield,
        Shell_Count,
        LifeSteal,
        Tenacity,
        Health_Regen,
        Shield_Regen,
        IsStunned,
        IsMovementLocked,
        Is

    }
    //TODO: add base stats here like shield and hp;


    RegisterStatProfile<EntityStats> Stats;
    //damage queue can be cleared to allow a frame of invincibility on Shell break
    Queue<DamageSource> damageQueue;

    //the physics involved in the system
    Rigidbody physics;
    //TODO: add a thing so that DOTs can persist thru shells, NVM actually explanation in OneNote
    //List<DamageSources> DamageSources;
}