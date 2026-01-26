using Cinemachine;
using HeneGames.Airplane;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    [Header("Levels")]
    [SerializeField] private Runway[] runways; // Runway_A, Runway_B, ...
    private int currentLevel = 0;



    private bool missionCompleted;
    public bool MissionCompleted
    {
        get { return missionCompleted; }
    }
    [Header("Camera")]
    [SerializeField] private SimpleAirplaneCamera airplaneCamera;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //missionCompletePanel.SetActive(false);
        missionCompleted = false;


        RunwayIdicator indicator = FindObjectOfType<RunwayIdicator>();
        if (indicator != null)
        {
            indicator.SetRunway(runways[currentLevel].landingAdjuster);
        }
    }

    private void Update()
    {
        
        

        if (missionCompleted) return; 

        // Landing check
        if (runways[currentLevel].AirplaneLandingCompleted())
        {
            CompleteLevel();
        }

        
    }


    void CompleteLevel()
    {
        missionCompleted = true;
        Debug.Log("LEVEL " + (currentLevel + 1) + " COMPLETED");

        //// Show panel
        //if (missionCompletePanel != null)
        //    missionCompletePanel.SetActive(true);

        // Freeze plane
        SimpleAirPlaneController plane = FindObjectOfType<SimpleAirPlaneController>();
        if (plane != null)
        {
            plane.enabled = false;
        }

        // Freeze camera input
        SimpleAirplaneCamera cameraScript = FindObjectOfType<SimpleAirplaneCamera>();
        if (cameraScript != null)
        {
            cameraScript.enabled = false; // disable camera update
        }


        UiManager.Instance.ShowMissionComplete();

    }

    public void NextLevel()
    {
        

        
        
        // Reset plane
        SimpleAirPlaneController plane = FindObjectOfType<SimpleAirPlaneController>();
        if (plane != null)
        {
            plane.ResetPlane();
            plane.enabled = true; // re-enable input
        }

        // Reset camera
        SimpleAirplaneCamera cameraScript = FindObjectOfType<SimpleAirplaneCamera>();
        if (cameraScript != null)
        {
            cameraScript.enabled = true; // re-enable camera update
        }

        // Cursor lock again
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        // Next level
        currentLevel++;
        if (currentLevel >= runways.Length)
            currentLevel = 0;

        missionCompleted = false;

        RunwayIdicator indicator = FindObjectOfType<RunwayIdicator>();
        if (indicator != null)
        {
            indicator.SetRunway(runways[currentLevel].landingAdjuster);
        }


    }







}
