using Cinemachine;
using HeneGames.Airplane;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    [Header("Levels")]
    [SerializeField] private Runway[] runways; // Runway_A, Runway_B, ...
    private int currentLevel = 0;

    [Header("UI")]
    [SerializeField] private GameObject missionCompletePanel;

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
        missionCompletePanel.SetActive(false);
        missionCompleted = false;


        RunwayIdicator indicator = FindObjectOfType<RunwayIdicator>();
        if (indicator != null)
        {
            indicator.SetRunway(runways[currentLevel].landingAdjuster);
        }
    }

    private void Update()
    {
        
        

        if (missionCompleted) return; // comment karo debugging ke liye agar log nahi aa rahe

        // Landing check
        if (runways[currentLevel].AirplaneLandingCompleted())
        {
            CompleteLevel();
        }

        // Keyboard Next Level
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("KEYBOARD NEXT LEVEL WORKING");
            NextLevel();
        }
    }


    void CompleteLevel()
    {
        missionCompleted = true;
        Debug.Log("LEVEL " + (currentLevel + 1) + " COMPLETED");

        // Show panel
        if (missionCompletePanel != null)
            missionCompletePanel.SetActive(true);

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

        // Optional: unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NextLevel()
    {
        Debug.Log("NEXT LEVEL BUTTON CLICKED");

        // Hide panel
        if (missionCompletePanel != null)
            missionCompletePanel.SetActive(false);

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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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
