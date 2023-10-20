using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupanthaPaul
{
	public class CameraFollow : MonoBehaviour
	{
	    [SerializeField]
		private Transform target;
		[SerializeField]
		private float smoothSpeed = 0.125f;
		public Vector3 offset;
		[Header("Camera bounds")]
		public Vector3 minCamerabounds;
		public Vector3 maxCamerabounds;

		//public 
		private bool isFollowing = true;

        private void FixedUpdate()
		{
			Vector3 desiredPosition = target.position + offset;
			var pos = transform.position;
			Vector3 smoothedPosition = Vector3.Lerp(pos, desiredPosition, smoothSpeed);
			pos = smoothedPosition;

			// clamp camera's position between min and max
			pos = new Vector3(
				Mathf.Clamp(pos.x, minCamerabounds.x, maxCamerabounds.x),
				Mathf.Clamp(pos.y, minCamerabounds.y, maxCamerabounds.y),
				Mathf.Clamp(pos.z, minCamerabounds.z, maxCamerabounds.z)
				);
			transform.position = pos;
		}

		public void SetTarget(Transform targetToSet)
		{
			target = targetToSet;
        }

		public void ToggleFollowing(bool follow)
		{
			isFollowing = follow;
		}
    }
}
