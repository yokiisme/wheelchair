using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;


namespace MoreMountains.TopDownEngine
{
	public class LoftLevelManager : LevelManager
	{

		protected override void SpawnMultipleCharacters()
		{
			PointsOfEntryStorage point = GameManager.Instance.GetPointsOfEntry(SceneManager.GetActiveScene().name);
			if ((point != null) && (PointsOfEntry.Length >= (point.PointOfEntryIndex + 1)))
			{
				Players[0].RespawnAt(PointsOfEntry[point.PointOfEntryIndex], point.FacingDirection);
				TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[0]);

				Players[1].RespawnAt(PointsOfEntry[point.PointOfEntryIndex], point.FacingDirection);
				TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[1]);
				return;
			}

			if (InitialSpawnPoint != null)
			{
				InitialSpawnPoint.SpawnPlayer(Players[0]);
				TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[0]);
				InitialSpawnPoint.SpawnPlayer(Players[1]);
				Players[1].transform.position = new Vector3(Players[0].transform.position.x + 1, Players[0].transform.position.y, Players[0].transform.position.z);
				TopDownEngineEvent.Trigger(TopDownEngineEventTypes.SpawnComplete, Players[1]);
				return;
			}

		}
	}
}






