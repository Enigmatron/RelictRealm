using UnityEngine;
using System.Collections;




public class Damage
{
	
	public string Name;

	//should hold a reference to the damager and not a string
	public string Dealer;
	public int DamageEquation;

	struct DamagePayload{
		public int damage;
		public string Name;
		
		
		//should hold a reference to the damager and not a string
		public string Dealer; 

	}


	//should hold a reference to the damager and not a string
	public Damage (string name, string dealer, int totalDamage)
	{
		Name = name; 
		Dealer = dealer;
		DamageEquation = totalDamage;
	}
}



#region Depreciated Code
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

#endregion