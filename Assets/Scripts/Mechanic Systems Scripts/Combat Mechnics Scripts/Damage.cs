using UnityEngine;
using System.Collections;




public class Damage
{
	
	public string Name;
	public EntityState Dealer;
	public int DamageEquation;

	struct DamagePayload{
		public int damage;
		public string Name;
		public EntityState Dealer; 

	}

	public Damage (string name, EntityState dealer, int totalDamage)
	{
		Name = name; 
		Dealer = dealer;
		DamageEquation = totalDamage;
	}
}


/*
	public class Profile
	{
		
		public delegate int CustomValue (EntityState dealer, EntityState receiever);

		private CustomValue Value;
		string Name;
		//	Return_Int value;
		EntityState Dealer;
		//	IDamageable Receiver;

		//	private Value_Int Ints;

		public Return Return (EntityState reciever)
		{
			return new Return (Name, Dealer, Value (Dealer, reciever));
		}

		//	public Return_Int (Value_Int val)
		//	{
		//		Ints = val;
		//	}

		public Profile (string name, EntityState dealer, CustomValue intVal)
		{
			Name = name;
			Dealer = dealer;
			Value = new CustomValue (intVal);
		}
	}
*/