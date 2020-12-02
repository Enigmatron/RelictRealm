

// using UnityEngine.Events;
// using UnityEngine.EventSystems;
// using UnityEngine;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using StatisticSystem;
// using Damage;



// public enum Identities
// {
// 	Minion,
// 	Ulric,
// 	Lailana,
// 	Khastor,
// 	Izusa,
// 	Kwinaga,
// 	Darwin,
// 	Kenjinn,
// 	Forte,
// 	Hero,
// 	Surge,
// 	Sagacion,
// 	AoYun,
// 	Val,
// 	Jyotian,
// 	Prophet,
// 	Bijou,
// 	Monster,
// 	ArrayNode,
// 	Tank,

// }

// public abstract class EntityIdentity : ScriptableObject
// {
// 	public enum Identities
// 	{
// 		Minion,
// 		Vulrick,
// 		Lailana,
// 		Khastor,
// 		Tresna,
// 		Curtraz,
// 		Yongar,
// 		Val,
// 		Belltheon,
// 		Izarr,
// 		Helgrim,
// 		GenericMonster

// 	}

// 	public enum PhotoIDSize
// 	{
// 		SplashArt,
// 		Large,
// 		Medium,
// 		Small

// 	}





// 	public Sprite ObtainPhotoID (PhotoIDSize size)
// 	{
// 		Sprite Temp = null;
// 		switch (size) {
// 		case PhotoIDSize.SplashArt:
// 			Temp = Resources.Load<Sprite> (GetName () + "_Photo_SplashArt");
// 			break;
// 		case PhotoIDSize.Large:
// 			Temp = Resources.Load<Sprite> (GetName () + "_Photo_Large");
// 			break;
// 		case PhotoIDSize.Medium:
// 			Temp = Resources.Load<Sprite> (GetName () + "_Photo_Medium");
// 			break;
// 		case PhotoIDSize.Small:
// 			Temp = Resources.Load<Sprite> (GetName () + "_Photo_Small");
// 			break;


// 		}
// 		return Temp;
// 	}



// 	public string GetName ()
// 	{
// 		return Enum.GetName (typeof(Identities), (int)ID);
// 	}

// 	static Identities id;

// 	public Identities ID {
// 		get {
// 			return id;
// 		}
// 	}


// 	/*
// 	public struct IDPhotoRange{
// 		public Sprite small;
// 		public Sprite medium;
// 		public Sprite large;
// //		Resources

// 	}
// */
// 	FormInfo form;
// 	KitInfo abilityKit;
// 	LifeResource lRes;

// 	//	public int Override ()
// 	//	{
// 	//		return 0;
// 	//	}

// 	//	public EntityIdentity ()
// 	//	{
// 	//
// 	//		abilityKit = new KitInfo (null, new Ability[]{ Ability.Builder.Create ().Intialize () });
// 	//	}
// }



