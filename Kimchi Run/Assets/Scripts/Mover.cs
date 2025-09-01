using UnityEngine;

public class Mover : MonoBehaviour
{

    [Header("Settings")]
    public float moveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
    }
}
