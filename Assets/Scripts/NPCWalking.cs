using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCWalking : MonoBehaviour
{
    [Header("NPC Settings")]
    public float moveSpeed = 5f;
    public float changeDir = 10f;
    public float pause = 4f;

    [Header("Talk")]
    public GameObject box;
    public TMP_Text talkText;
    public List<string> dialogueLines;

    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private float changeDirTimer;
    private Animator anim;
    private bool isPaused;
    private Vector2 originPosition;
    private Vector2 targetPos;

    private int dialogueIndex = 0;
    private bool isTalking = false;
    private bool isPlayerNearby = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        originPosition = rb.position;
        box.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Z))
        {
            if (!isTalking)
            {
                StartDialogue();
            }
            else
            {
                AdvanceDialogue();
            }
        }

        if (isPaused || isTalking)
        {
            return;
        }

        changeDirTimer -= Time.deltaTime;
        if (changeDirTimer <= 0)
        {
            PickDirection();
        }
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        anim.SetBool("isMoving", true);
        anim.SetFloat("X", moveDirection.x);
        anim.SetFloat("Y", moveDirection.y);

    }

    void PickDirection()
    {
        float targetX = Random.Range(originPosition.x - 3f, originPosition.x + 3f);
        float targetY = Random.Range(originPosition.y - 3f, originPosition.y + 3f);

        targetPos = new Vector2(targetX, targetY);
        moveDirection = (targetPos - rb.position).normalized;
        changeDirTimer = changeDir;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPaused = true;
            isPlayerNearby = true;
            anim.SetBool("isMoving", false);
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation; //Prevent NPC from sliding away.
            return;
        }

        isPaused = true;
        anim.SetBool("isMoving", false);

        Vector2 awayFromWall = Vector2.Reflect(moveDirection, collision.contacts[0].normal);
        moveDirection = awayFromWall.normalized;

        StartCoroutine(ResumePause());
    }
    IEnumerator ResumePause()
    {
        yield return new WaitForSeconds(pause);
        isPaused = false;
        changeDirTimer = changeDir;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (!isTalking)
            {
                isPaused = false;
            }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void StartDialogue()
    {
        isTalking = true;
        dialogueIndex = 0;
        talkText.text = dialogueLines[dialogueIndex];
        box.SetActive(true);
    }

    void AdvanceDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueLines.Count)
        {
            talkText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        box.SetActive(false);
        isTalking = false;

        if (!isPlayerNearby)
        {
            isPaused = false;
        }
    }
}
