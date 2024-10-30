using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.TopDownEngine
{
	public enum MMCameraEventTypes { SetTargetCharacter, SetTargetSecondCharacter, SetConfiner, StartFollowing, StopFollowing, RefreshPosition, ResetPriorities, RefreshAutoFocus }

	public struct MMCameraEvent
	{
		public MMCameraEventTypes EventType;
		public Character TargetCharacter;
		public Character TargetSecondCharacter;
		public Collider Bounds;
		public Collider2D Bounds2D;

		public MMCameraEvent(MMCameraEventTypes eventType, Character targetCharacter = null, Character targetSecondCharacter = null, Collider bounds = null, Collider2D bounds2D = null)
		{
			EventType = eventType;
			TargetCharacter = targetCharacter;
			TargetSecondCharacter = targetSecondCharacter;
			Bounds = bounds;
			Bounds2D = bounds2D;
		}

		static MMCameraEvent e;
		public static void Trigger(MMCameraEventTypes eventType, Character targetCharacter = null, Collider bounds = null, Collider2D bounds2D = null)
		{
			e.EventType = eventType;
			e.Bounds = bounds;
			e.Bounds2D = bounds2D;
			if (eventType == MMCameraEventTypes.SetTargetCharacter)
			{
				e.TargetCharacter = targetCharacter;
			}
			if (eventType == MMCameraEventTypes.SetTargetSecondCharacter)
			{
				e.TargetSecondCharacter = targetCharacter;
			}
			MMEventManager.TriggerEvent(e);
		}
	}
}