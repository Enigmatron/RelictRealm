using UnityEngine;
using System.Collections;




public class DamageSource
{
	
	public string DamageSourceName;

	//should hold a reference to the damager and not a string
	public Entity entity;
	public delegate float DamageEquation(Entity entity);
	DamageEquation damageEQ;
	struct DamagePayload{
		public int damage;
		public string Name;
		
		
		//should hold a reference to the damager and not a string
		public string Dealer; 

	}


	//should hold a reference to the damager and not a string
	public DamageSource (string name, ref DamageEquation eq, Entity ent) 
	{
		DamageSourceName = name;
		damageEQ = eq;
		entity = ent;
	}
}
