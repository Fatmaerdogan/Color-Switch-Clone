using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	Transform player;
    private void Start()
    {
		player = GameObject.Find("Player").transform;
    }

    void Update ()
	{
		if (player == null) return;
		if (player.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
		}
	}

}
