using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(CharacterInput))]
[RequireComponent(typeof(CheckPointsHandler))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private float respawnTime; 

    private CharacterInput inputController;
    private CheckPointsHandler checkpointHandler;

    private string disablingObjectTag;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        inputController = this.GetComponent<CharacterInput>();
        checkpointHandler = this.GetComponent<CheckPointsHandler>();

    }

    private void Start()
    {
        disablingObjectTag = GameController.instance.GetDisablingObjectTag();
    }

    private void RespawnPlayer(float _timeBeforeRespawn = 2f)
    {
        StartCoroutine(RespawnCorrutine(_timeBeforeRespawn));
    }

    private IEnumerator RespawnCorrutine (float _timeBeforeRespawn)
    {
        yield return new WaitForSeconds(_timeBeforeRespawn);

        if (checkpointHandler != null)
        {
            Checkpoint lastCheckpoint = checkpointHandler.GetLatestCheckpoint();

            if (lastCheckpoint != null)
            {
                Debug.LogWarning("Respawnging at checkpoint " + lastCheckpoint.name);
                SpawnPlayer(lastCheckpoint.transform);
            }
            else
            {
                Debug.LogWarning("Respawnging at respawn");
                SpawnPlayer(GameController.instance.GetInitialSpawnPoint());
            }
        }

    }

    public void SpawnPlayer(Transform _spawnPointTransform)
    {
        isAlive = true;
        inputController.EnableInputs();

        this.transform.position = _spawnPointTransform.position;
        this.transform.forward = _spawnPointTransform.forward;
    }

    private void KillPlayer()
    {
        Debug.Log("killing player");

        // time to disable the player inputs
        inputController.DisableInputs();

        isAlive = false;
        rb.velocity = Vector3.zero;

        Debug.Log("Disabling controls due to impact");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive)
        {
            if (collision.transform.tag == disablingObjectTag)
            {
                KillPlayer();

                RespawnPlayer(respawnTime);
            }
        }    
    }

   

}
