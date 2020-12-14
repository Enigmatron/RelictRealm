// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using System;



// public abstract partial class ActiveEntity
// {
//     #region EntityDetection

//     //TODO: add the combat timer: a timer that resets on damage taken; the section is gonna be indeterminant for now;
//     SphereCollider detectionSphere;
//     public bool isNearVisibleEnemy
//     {
//         get;
//         protected set;
//     }
//     public bool isNearEnemy
//     {
//         get;
//         protected set;
//     }
//     public bool isNearVisibleAlly
//     {
//         get;
//         protected set;
//     }
//     public bool isNearAlly
//     {
//         get;
//         protected set;
//     }
//     public bool isNearVisibleNeutral
//     {
//         get;
//         protected set;
//     }
//     public bool isNearNeutral
//     {
//         get;
//         protected set;
//     }

//     public bool Combat
//     {
//         get
//         {
//             return isNearEnemy;
//             // || Damage_Timer.Finished;
//         }
//     }

//     //this is for the out of combat system
//     // Progressor damage_timer;

//     // public Progressor Damage_Timer
//     // {
//     //     get
//     //     {
//     //         return damage_timer;
//     //     }
//     // }

//     // Bit shift the index of the layer (8) to get a bit mask
//     int layerMask = 1 << 8;

//     RaycastHit entityDetectionHit;


//     [Flags]
//     public enum EntityDetectionFlag : byte
//     {
//         onEnter = 1,
//         onStay = 2,
//         onExit = 4,
//         onInVision = 8, //gets turned off on stay
//         OnVisionStay = 16,
//         OnOutVision = 32, //gets turned off
//     }
//     //replace the events below
//     //the int is a flag for what event is being called whether it is true or not;
//     //ActiveEntity is the subject of the event;
//     //The events need to decern what teamvalue the entity has
//     //holds a list of methods that check the team value and flag within the UnityAction for these UnityEvents
//     List<UnityEvent<Dictionary<ActiveEntity, int>>> EntityDetectionEvents;

//     //uses the same flag as EntityDectionEvents
//     //the flag can tell you if the entity is in vision
//     //these are kept seperate as to maintain the isnearvariable for both to quickly get out of combat
//     public Dictionary<ActiveEntity, int> nearAllies;
//     //neutral is
//     public Dictionary<ActiveEntity, int> nearEnemies;
//     public Dictionary<ActiveEntity, int> nearNeutrals;


    


//     //TODO: has to be called on fixed update
//     public partial void EntityDectionEventCall()
//     {
//         //placed here to see
//         //Dictionary< EntityDetectionFlag, List<UnityEvent<Dictionary<ActiveEntity, int>>>> EntityDetectionEvents;
//         foreach (UnityEvent<Dictionary<ActiveEntity, int>> y in EntityDetectionEvents)
//         {
//             y.Invoke(nearAllies);
//             y.Invoke(nearEnemies);
//             y.Invoke(nearNeutrals);
//             foreach (KeyValuePair<ActiveEntity, int> x in nearAllies)
//             {
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.onExit))
//                 {
//                     nearAllies.Remove(x.Key);
//                     continue;
//                 }
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.OnOutVision))
//                 {
//                     MathLambda.FlagOff(x.Value, (int)EntityDetectionFlag.OnOutVision + (int)EntityDetectionFlag.onInVision + (int)EntityDetectionFlag.OnVisionStay);
//                 }
//             }
//             foreach (KeyValuePair<ActiveEntity, int> x in nearEnemies)
//             {
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.onExit))
//                 {
//                     nearEnemies.Remove(x.Key);
//                     continue;
//                 }
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.OnOutVision))
//                 {
//                     MathLambda.FlagOff(x.Value, (int)EntityDetectionFlag.OnOutVision + (int)EntityDetectionFlag.onInVision + (int)EntityDetectionFlag.OnVisionStay);
//                 }
//             }
//             foreach (KeyValuePair<ActiveEntity, int> x in nearNeutrals)
//             {
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.onExit))
//                 {
//                     nearNeutrals.Remove(x.Key);
//                     continue;
//                 }
//                 if (MathLambda.FlagCheck(x.Value, (int)EntityDetectionFlag.OnOutVision))
//                 {
//                     MathLambda.FlagOff(x.Value, (int)EntityDetectionFlag.OnOutVision + (int)EntityDetectionFlag.onInVision + (int)EntityDetectionFlag.OnVisionStay);
//                 }
//             }
//         }


//     }

//     //TODO: write the code, use ray cast and check the head, upper legs, and body and return tru if any are 'seen'
    

//     //add to a dictionary of near enemies and detect if they're in vision
//     //if: in vision then: add to in vision entities of enemies or allies;
//     //if: not in vision then: add enemies and allies to dictionary of such;
//     protected partial void OnEntityEnter(Collider other)
//     {
//         ActiveEntity ent = other.GetComponent<ActiveEntity>();
//         if (ent != null)
//         {
//             if (isEntityEnemy(ent))
//             {
//                 nearEnemies.Add(ent, (int)EntityDetectionFlag.onEnter);
//                 isNearEnemy = true;
//             }
//             if (isEntityAlly(ent))
//             {
//                 nearAllies.Add(ent, (int)EntityDetectionFlag.onEnter);
//                 isNearAlly = true;
//             }
//             if (isEntityNeutral(ent))
//             {
//                 nearNeutrals.Add(ent, (int)EntityDetectionFlag.onEnter);
//                 isNearNeutral = true;
//             }
//         }
//     }

//     protected partial void OnEntityExit(Collider other)
//     {

//         ActiveEntity ent = other.GetComponent<ActiveEntity>();
//         if (ent != null)
//         {
//             //TODO: add the appropriate flag
//             if (isEntityAlly(ent))
//             {
//                 nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlag.onExit);
//                 nearAllies[ent] = MathLambda.FlagOff(nearAllies[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlag.OnOutVision);
//                 if (nearAllies.Count == 0)
//                 {
//                     isNearAlly = false;
//                     isNearVisibleAlly = false;
//                 }
//                 else
//                 {

//                     foreach (KeyValuePair<ActiveEntity, int> item in nearAllies)
//                     {
//                         if (
//                             MathLambda.FlagCheck(item.Value, (int)EntityDetectionFlag.OnVisionStay + (int)EntityDetectionFlag.onInVision)
//                         )
//                         {
//                             isNearVisibleAlly = true;
//                             break;
//                         }
//                     }
//                 }

//             }
//             if (isEntityEnemy(ent))
//             {
//                 nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlag.onExit);
//                 nearEnemies[ent] = MathLambda.FlagOff(nearEnemies[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlag.OnOutVision);
//                 isNearEnemy = nearEnemies.Count == 0 ? false : true;
//                 if (nearEnemies.Count == 0)
//                 {
//                     isNearEnemy = false;
//                     isNearVisibleEnemy = false;
//                 }
//                 else
//                 {

//                     foreach (KeyValuePair<ActiveEntity, int> item in nearEnemies)
//                     {
//                         if (
//                             MathLambda.FlagCheck(item.Value, (int)EntityDetectionFlag.OnVisionStay + (int)EntityDetectionFlag.onInVision)
//                         )
//                         {
//                             isNearVisibleEnemy = true;
//                             break;
//                         }
//                     }
//                 }
//             }
//             if (isEntityNeutral(ent))
//             {
//                 nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlag.onExit);
//                 nearNeutrals[ent] = MathLambda.FlagOff(nearNeutrals[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlag.OnOutVision);
//                 isNearNeutral = nearNeutrals.Count == 0 ? false : true;
//                 if (nearNeutrals.Count == 0)
//                 {
//                     isNearNeutral = false;
//                     isNearVisibleNeutral = false;
//                 }
//                 else
//                 {

//                     foreach (KeyValuePair<ActiveEntity, int> item in nearNeutrals)
//                     {
//                         if (
//                             MathLambda.FlagCheck(item.Value, (int)EntityDetectionFlag.OnVisionStay + (int)EntityDetectionFlag.onInVision)
//                         )
//                         {
//                             isNearVisibleNeutral = true;
//                             break;
//                         }
//                     }
//                 }
//             }
//         }
//     }

//     protected partial void OnEnemyStay(Collider other)
//     {
//         ActiveEntity ent = other.GetComponent<ActiveEntity>();
//         if (ent != null)
//         {
//             if (isEntityAlly(ent))
//             {
//                 nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlag.onStay);
//             }
//             if (isEntityEnemy(ent))
//             {
//                 nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlag.onStay);
//             }
//             if (isEntityNeutral(ent))
//             {
//                 nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlag.onStay);
//             }

//             if (entityVisionCalc(ent))
//             {
//                 if (isEntityAlly(ent))
//                 {
//                     nearAllies[ent] = MathLambda.FlagOn(nearAllies[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 }
//                 if (isEntityEnemy(ent))
//                 {
//                     nearEnemies[ent] = MathLambda.FlagOn(nearEnemies[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 }
//                 if (isEntityNeutral(ent))
//                 {
//                     nearNeutrals[ent] = MathLambda.FlagOn(nearNeutrals[ent], (int)EntityDetectionFlag.OnVisionStay);
//                 }
//             }
//         }
//     }

//     #endregion
// }