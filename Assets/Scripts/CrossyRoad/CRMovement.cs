using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using Unity.Mathematics;

public class CRMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Animator animator;
    public int Score { get; private set; } = 0;
    int highScore = 0;
    public int HighScore { get => highScore; }
    private float maxZPosition = 0f;
    private const string CRBestScoreKey = "CRBestScore";
    private bool scoreUIShown = false;
    public ParticleSystem deathEffect;
    private MeshRenderer meshRenderer;

    void Start()
    {
        targetPosition = transform.position;
        animator = GetComponentInChildren<Animator>();
        highScore = PlayerPrefs.GetInt(CRBestScoreKey, 0);
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (!isMoving)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                direction = Vector3.forward;
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.z > maxZPosition - 4f) //Cannot go back three times limit to two times. 
                direction = Vector3.back;
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                direction = Vector3.right;

            if (direction != Vector3.zero)
            {
                //Debug.Log("Hop");
                targetPosition = transform.position + direction * 2f;
                targetPosition.x = Mathf.Clamp(targetPosition.x, -24, 22);
                if (animator != null)
                    animator.SetTrigger("Hop");
                StartCoroutine(MoveToPosition(targetPosition));
            }
            CRUIManager.Instance.UpdateScore();
        }
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        if (transform.position.z > maxZPosition)
        {
            maxZPosition = transform.position.z;
            Score = Mathf.FloorToInt((maxZPosition / 2) - 3);
        }
        isMoving = false;
    }

    void UpdateScore()
    {
        if (highScore < Score)
        {
            Debug.Log("Highscore");
            highScore = Score;
            PlayerPrefs.SetInt(CRBestScoreKey, highScore);
        }
    }

    void OnCollisionEnter(Collision collision) // Will render the mesh thus making it invisible. NOT DESTROY since we still need the player to get the UI and particles to play
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            UpdateScore();
            StartCoroutine(ShowDeath());
            meshRenderer.enabled = false;
        }
    }
    IEnumerator ShowDeath()
    {
        Vector3 deathPosition = transform.position;
        ParticleSystem ps = Instantiate(deathEffect, deathPosition, Quaternion.identity);
        ps.Play();
        yield return new WaitForSeconds(0.5f);
        if (!scoreUIShown)
        {
            CRUIManager.Instance.SetScoreUI();
            scoreUIShown = true;
        }
        yield return new WaitForSeconds(ps.main.duration);
        Destroy(ps.gameObject);
        gameObject.SetActive(false);
    }
}
