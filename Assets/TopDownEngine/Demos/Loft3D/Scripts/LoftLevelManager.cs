using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;


namespace MoreMountains.TopDownEngine
{

	public class LoftLevelManager : LevelManager
	{
		public static bool LockMove = false;

		public override void SetFollowPosition(string playerid)
		{
			if (G_Follow != null)
			{
				float dis = Vector3.Distance(Players[0].transform.position, Players[1].transform.position);
				if (dis > 15 && Players[0].ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead &&
					Players[1].ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead &&
					!GUIManager.Instance.DeathScreen.activeSelf && !GUIManager.Instance.PauseScreen.activeSelf)
				{
					GUIManager.Instance.RemandPOP.SetActive(true);
				}
				else
				{
					GUIManager.Instance.RemandPOP.SetActive(false);
				}
					

				if (Players[0].ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead &&
					Players[1].ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead)
				{
					G_Follow.transform.position = Players[1].transform.position;
				}
				else if (Players[0].ConditionState.CurrentState != CharacterStates.CharacterConditions.Dead &&
					Players[1].ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead)
				{
					G_Follow.transform.position = Players[0].transform.position;
				}
				else if (Players[0].ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead &&
					Players[1].ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead)
				{
					G_Follow = null;
					return;
				}
				else
				{
					G_Follow.transform.position = (Players[0].transform.position + Players[1].transform.position) / 2;
				}
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






