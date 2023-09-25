using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField] private float speed = 100f;
	void Update () {
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}
