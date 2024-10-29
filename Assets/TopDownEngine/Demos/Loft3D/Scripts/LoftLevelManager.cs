using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;


namespace MoreMountains.TopDownEngine
{

	public class LoftLevelManager : LevelManager
	{

		public override void PlayerDead(Character playerCharacter)
		{
			//if (Players.Count < 2)
			//{
			//	StartCoroutine(PlayerDeadCo());
			//}

			if (playerCharacter.PlayerID == "Player1" || playerCharacter.PlayerID == "Player2")
			{

				//playerCharacter.CharacterAnimator.Play("dying");

			}


		}


		protected override void SpawnMultipleCharacters()
		{
			if (PointsOfEntry.Length == Players.Count)
			{
				for (int i = 0; i < Players.Count; i++)
				{
					InitialSpawnPoint.SpawnPlayer(Players[i]);
					Players[i].RespawnAt(PointsOfEntry[i], Character.FacingDirections.North);
					TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[i]);
				}
			}


			//PointsOfEntryStorage point = GameManager.Instance.GetPointsOfEntry(SceneManager.GetActiveScene().name);
			//Players[0].RespawnAt(PointsOfEntry[0], Character.FacingDirections.East);
			//Players[1].RespawnAt(PointsOfEntry[1], point.FacingDirection);
			//if ((point != null) && (PointsOfEntry.Length >= (point.PointOfEntryIndex + 1)))
			//{

			//	Players[0].RespawnAt(PointsOfEntry[point.PointOfEntryIndex], point.FacingDirection);
			//	TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[0]);

			//	Players[1].RespawnAt(PointsOfEntry[point.PointOfEntryIndex], point.FacingDirection);
			//	TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[1]);
			//	return;
			//}

			//if (InitialSpawnPoint != null)
			//{
			//	InitialSpawnPoint.SpawnPlayer(Players[0]);
			//	TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[0]);
			//	InitialSpawnPoint.SpawnPlayer(Players[1]);
			//	Players[1].transform.position = new Vector3(Players[0].transform.position.x + 1, Players[0].transform.position.y, Players[0].transform.position.z);
			//	TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[1]);
			//	return;
			//}

		}
	}
}






