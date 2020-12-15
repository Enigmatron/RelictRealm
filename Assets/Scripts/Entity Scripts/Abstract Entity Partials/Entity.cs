using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;



public abstract partial class Entity : MonoBehaviour
{
    public enum EntityStats
    {
        Health, //
        Movespeed, //
        JumpSpeed, //
        Shield, // 
        Health_Regen, //
        Shield_Regen, //
        Shell_Count, // 1-9
        LifeSteal, // 0-1f
        Tenacity, //0-1f reduced time of cc received
        Stun, //0-1f
        Snare, //0-1f
        DamageImmunity_Shield, //0-1f
        DamageImmunity_Health, //0-1f
        CCImmunity, // 0-1f
        Armor, // 0-1f reduction in the damage received
        Silence, //any val = true


    }
    //TODO: add base stats here like shield and hp;

    protected List<MovementCommand> movementCommands;
    protected RegisterProfile<EntityStats> Stats;
    //damage queue can be cleared to allow a frame of invincibility on Shell break
    protected Queue<DamageSource> damageQueue;

    //the physics involved in the system
    protected Rigidbody physics;
    //TODO: add a thing so that DOTs can persist thru shells, NVM actually explanation in OneNote
    //List<DamageSources> DamageSources;
}