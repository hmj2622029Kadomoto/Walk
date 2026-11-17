using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float moveSpeed = 10;

	Inputs inputs;
	CharacterController controller;

	Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // コンポーネント取得
		inputs = GetComponent<Inputs>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
