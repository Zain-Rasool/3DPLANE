using HeneGames.Airplane;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    [SerializeField] private Runway runway;
    [SerializeField] private GameObject missionCompletePanel;

    private bool missionCompleted = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        missionCompletePanel.SetActive(false);
    }

    private void Update()
    {
        if (missionCompleted) return;

        // ⭐ YAHI MAIN LOGIC HAI
        if (runway.AirplaneLandingCompleted())
        {
            CompleteMission1();
        }
    }

    void CompleteMission1()
    {
        missionCompleted = true;

        Debug.Log("MISSION 1 COMPLETED");

        Time.timeScale = 0f; // GAME STOP
        missionCompletePanel.SetActive(true);
    }
}
