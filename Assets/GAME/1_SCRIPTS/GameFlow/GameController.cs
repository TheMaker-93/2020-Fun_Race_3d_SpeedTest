using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[RequireComponent(typeof(GameSceneManager))]
[RequireComponent(typeof(GameCanvasManager))]
public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameSceneManager gameSceneManager;
    [SerializeField] private GameCanvasManager gameCanvasManager;

    [Header("Game Tags")]
    [SerializeField] private string playerTag;
    [SerializeField] private string disablingObjectTag;     // tag for the obstacles
    [SerializeField] private string checkpointTag;

    [SerializeField] private Player playerPrefab;
    [SerializeField] private int playersAmount;

    [SerializeField] private List<Player> players;
    [SerializeField] private PathManager levelPathManager;

    [SerializeField] private Transform initialSpawnTransform;

    [Header("End")]
    [SerializeField] private bool levelEndReached = false;


    public Transform GetInitialSpawnPoint()
    {
        return initialSpawnTransform;
    }
    public string GetPlayerTag()
    {
        return playerTag;
    }
    public string GetDisablingObjectTag()
    {
        return disablingObjectTag;
    }
    public string GetCheckpointTag()
    {
        return checkpointTag;
    }
    public void OnLevelEndReached()
    {
        levelEndReached = true;

        gameCanvasManager.ShowEndGameCanvas();
        // do all the canvas things (fancy stuff)
    }

    public void RestartLevel()
    {
        Debug.LogWarning("Reloading scene");
        gameSceneManager.ReloadScene();
    }

    private void Awake()
    {
        instance = this;

        if (players == null)
            players = new List<Player>();
        gameSceneManager = this.GetComponent<GameSceneManager>();
        gameCanvasManager = this.GetComponent<GameCanvasManager>();

        if (playerTag == "")
            Debug.LogError("You need to define a tag for the player");
        if (disablingObjectTag == "")
            Debug.LogError("You need to define a tag for the disabling objects");
        if (checkpointTag == "")
            Debug.LogError("You need to define a tag for the checkpoints");
    }

    private void Start()
    {
        InstantiatePlayers();
    }


    private void InstantiatePlayers()
    {
        for (int index = 0; index < playersAmount; index++)
        {
            Player newPlayer = GameObject.Instantiate<Player>(playerPrefab);
        
            newPlayer.SpawnPlayer(initialSpawnTransform);

            newPlayer.transform.position = initialSpawnTransform.position;
            newPlayer.transform.forward = initialSpawnTransform.forward;

            newPlayer.GetComponent<PathFollowing>().Setpath(levelPathManager.GetLevelPath());
        }
    }

}
