using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;


namespace MoreMountains.TopDownEngine
{

	public class LoftLevelManager : LevelManager
	{

		public override void SetFollowPosition(string playerid)
		{
			if (G_Follow != null)
			{
				G_Follow.transform.position = (Players[0].transform.position + Players[1].transform.position) / 2;
			}
		}


		protected override void SpawnMultipleCharacters()
		{
			if (PointsOfEntry.Length == Players.Count)
			{
				for (int i = 0; i < Players.Count; i++)
				{
					InitialSpawnPoint.SpawnPlayer(Players[i]);
					Players[i].RespawnAt(PointsOfEntry[i], Character.FacingDirections.West);
					TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[i]);
				}
			}

			if (G_Follow != null)
			{
				G_Follow.transform.position =( Players[0].transform.position + Players[1].transform.position) / 2;
			}
		}
	}
}






