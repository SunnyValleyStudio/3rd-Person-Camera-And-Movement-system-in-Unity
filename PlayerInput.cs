/*
	Made by Sunny Valle Studio
	(https://svstudio.itch.io)
*/
using System;
using UnityEngine;

namespace SVS
{
	public class PlayerInput : MonoBehaviour, IInput
	{
		public Action<Vector2> OnMovementInput { get; set; }
		public Action<Vector3> OnMovementDirectionInput { get; set; }

		private void Start()
		{
			//Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			GetMovementInput();
			GetMovementDirection();
		}

		private void GetMovementDirection()
		{
			var cameraForewardDIrection = Camera.main.transform.forward;
			Debug.DrawRay(Camera.main.transform.position, cameraForewardDIrection * 10, Color.red);
			var directionToMoveIn = Vector3.Scale(cameraForewardDIrection, (Vector3.right + Vector3.forward));
			Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
			OnMovementDirectionInput?.Invoke(directionToMoveIn.normalized);
		}

		private void GetMovementInput()
		{
			Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			OnMovementInput?.Invoke(input);
		}
	}
}

