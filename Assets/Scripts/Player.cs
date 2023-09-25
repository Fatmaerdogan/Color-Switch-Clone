using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private List<Color> Colors=new List<Color>();

    Rigidbody2D rb;
    SpriteRenderer sr;

    ColorType currentColor;

    void Start ()
	{
		rb=GetComponent<Rigidbody2D>();
		sr=GetComponent<SpriteRenderer>();
		SetRandomColor();
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) Jump();
	}
	void Jump()
	{
        rb.velocity = Vector2.up * jumpForce;
    }
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag( "ColorChanger"))
		{
			SetRandomColor();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor.ToString())
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, Colors.Count);

		currentColor =(ColorType)index;
		sr.color = Colors[index];
	}
}

public enum ColorType
{ 
	Cyan,
	Yellow,
	Magenta,
	Pink
}