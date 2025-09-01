using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    // 플레이어 점프, 착지, 달리기 구현을 위한 애니메이션 연동
    public Animator PlayerAnimator;

    // 플레이어 죽음
    public BoxCollider2D PlayerCollider;

    public Boolean isGrounded = true;

    private bool isInvincible = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayerAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    public void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);

    }

    void Hit()
    {
        GameManager.Instance.Lives -= 1;
    }

    void Heal()
    {
        GameManager.Instance.Lives = Math.Min(3, GameManager.Instance.Lives + 1);
    }

    void StartInvicible()
    {
        isInvincible = true;
        Invoke("StopInvicible", 5f);
    }

    void StopInvicible()
    {
        isInvincible = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy") {
            if (!isInvincible)
            {
                Destroy(collider.gameObject);
            }
            Hit();
        }

        else if (collider.gameObject.tag == "food") {
            Destroy(collider.gameObject);
            Heal();
        }

        else if (collider.gameObject.tag == "golden") {
            Destroy(collider.gameObject);
            StartInvicible();
        }
    }
}
