using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		// マウスカーソル非表示
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
    }
}
