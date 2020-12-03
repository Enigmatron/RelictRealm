using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

using UnityEngine.Networking.Match;

public class TeamState
{
	protected TeamState ()
	{
	}

	// public TeamInstance Team;
	public bool ForcedVisibility;
	public int TotalDeaths;
	public int TotalKills;


	// public TeamState (TeamInstance team)
	// {
	// 	Team = team;
	// }


	//	private List<Player> players;
	//	public List<Player> Players{
	//		get{
	//			return players;
	//		}
	//	}
}

	




public class GameManager 
{
	public float GameTime;



	protected GameManager ()
	{
	}
	// guarantee this will be always a singleton only - can't use the constructor!




	//

	//	private TeamState iota_team;
	//	public TeamState IotaTeam{
	//		get{
	//			if (iota_team == null) {
	//				iota_team = new TeamState (TeamInstances.Iota);
	//			}
	//			return iota_team;
	//		}
	//	}
	//	private TeamState gamma_team;
	//	public TeamState GammaTeam{
	//		get{
	//			if (gamma_team == null) {
	//				gamma_team = new TeamState (TeamInstances.Gamma);
	//			}
	//			return gamma_team;
	//		}
	//	}

	public void OnServerInitialized ()
	{
		Debug.Log ("OnPlayerConnected");

	}


	//	public void DistributeCopy(IState from, IState to, ICopy collect){
	//		/// add code checking
	//		if (AccessCopy(collect.ID, to) != null)
	//			AccessCopy (collect.ID, to);
	//		to.Copies.Add (new DistributableObjectNode (collect, to, from));
	//	}
	//
	//	public Player AccessPlayer(SovereignState state){
	//		Player play = null;
	//		foreach(Player player in All_PLAYERS){
	//			if (player.State == state)
	//				play = player;
	//		}
	//
	//		return play;
	//	}
	//
	//
	//	public ICopyInstance[] AccessCopies(object key){
	//		List<ICopyInstance> item =  new List<ICopyInstance>();
	//		foreach(Player player in All_PLAYERS){
	//		foreach (DistributableObjectNode copy in player.State.Copies) {
	//			if (copy.Item.ID == key) {
	//					item.Add (copy.Instance);
	//			}
	//		}
	//		}
	//		return item.ToArray();
	//	}
	//
	//	public ICopy AccessCopy(object key, IState inside){
	//		ICopy item =  null;
	//		foreach (DistributableObjectNode copy in inside.Copies) {
	//			if (copy.Item.ID == key) {
	//				item = copy.Item;
	//			}
	//		}
	//		return item;
	//	}

	//	public void UpdatePlayers(){
	//		foreach (Player player in All_PLAYERS) {
	//			foreach (DistributableObjectNode node in player.Copies) {
	//				if (node.Instance is StepInstance) {
	//					StepInstance inst2 = (StepInstance)node.Instance;
	//					if (!inst2.finish && inst2.start) {
	//						if (inst2.forcedInterval > 0) {
	//							inst2.currentIntervalTime += Time.deltaTime;
	//							inst2.currentTime = BasicFunction.AddTillEqualTo (inst2.currentTime, Time.deltaTime, inst2.maxTime);
	//							if (inst2.onPhase.Resume != null) {
	//								inst2.onPhase.Resume ();
	//							}
	//							if (inst2.currentTime != inst2.maxTime) {
	//								float timesOver = (inst2.currentIntervalTime / inst2.forcedInterval);
	//								if (timesOver >= 1) {
	//									inst2.currentIntervalTime -= ((int)timesOver * inst2.forcedInterval);
	//									for (int i = 0; i >= timesOver; i++) {
	//										if (inst2.onPhase.Resume != null)
	//											inst2.onPhase.Resume ();
	//									}
	//								}
	//							} else {
	//								inst2.Complete ();
	//							}
	//
	//						} else {
	//							inst2.currentTime += Time.deltaTime;
	//							if (inst2.currentTime < inst2.maxTime) {
	//								if (inst2.onPhase.Resume != null) {
	//									inst2.onPhase.Resume ();
	//								}
	//							} else if (inst2.currentTime >= inst2.maxTime) {
	//								inst2.Complete ();
	//							}
	//						}
	//					}
	//
	//
	//				} else if (node.Instance is Step_MovementInstance) {
	//
	//				} else if (node.Instance is DOTInstance) {
	//
	//				} else if (node.Instance is CollectibleInstance) {
	//
	//				}
	//
	//			}
	//			foreach (RegisterableObjectNode node in player.Register) {
	//				if(node.Item is Step_MovementInstance){
	//
	//				} else if(node.Item  is DOTInstance){
	//
	//				} else if(node.Item  is CollectibleInstance){
	//
	//				}
	//			}
	//		}
	//	}




	//	public void OnMatchCreate (MatchResponse matchInfo)
	//	{
	//		//Network.TestConnection ();
	////		if (gamma_team == null) {
	////			gamma_team = new TeamState (TeamInstances.Gamma);
	////		}
	////		if (iota_team == null) {
	////			iota_team = new TeamState (TeamInstances.Iota);
	////		}
	////		foreach (Player player in All_PLAYERS) {
	////			if (player.TeamID == TeamInstances.Gamma) {
	////				gamma_team.Players.Add (player);
	////				player.Team = gamma_team;
	////			} else if (player.TeamID == TeamInstances.Iota) {
	////				iota_team.Players.Add (player);
	////				player.Team = iota_team;
	////			}
	////		}
	//	}

	//	void Update(){
	//			UpdatePlayers();
	//		}

	//		foreach (RegisterableObjectNode node in player.Register) {
	//			if(node.Item is Step_MovementInstance){
	//
	//			} else if(node.Item  is DOTInstance){
	//
	//			} else if(node.Item  is CollectibleInstance){
	//
	//			}
	//		}

	void Spawn ()
	{

	}

	void Awake ()
	{
		   
	}

// 	void LaunchServer ()
// 	{

// 		Network.InitializeServer (8, 25000, !Network.HavePublicAddress ());
// 		MasterServer.dedicatedServer = true;
// 		MasterServer.RegisterHost ("Fallen: Landwar", "JohnDoes game", "l33t game for all");
// //		NetworkServer.SpawnObjects ();
// //		SetMatchHost();
// 		StartServer ();
// 	}
	//
}


