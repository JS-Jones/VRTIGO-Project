using UnityEngine;
using System.IO;
using System;

public class CameraBackgroundChanger : MonoBehaviour
{
    public Camera cam;
    public GameObject Passthrough;
    public OVREyeGaze LeftEyeGaze;
    public OVREyeGaze RightEyeGaze;
    public StartSystem startMenu;
    public GameObject smiley;

    private float timer = 0f;
    private int state = 0; // 0 = solid, 1 = clear, 2 = skybox
    private string stateString = "solid";
    
    private string path, pathleft, pathright, headposfile, headrotfile;

    void OnEnable()
    {
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = Color.black; // Set to your preferred solid color
        Passthrough.SetActive(false);

        // Initialize file paths
        path = Path.Combine(Application.persistentDataPath, "CameraTrackingLogs");
        path = Path.Combine(path, StartSystem.playerName);
        path = Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        Directory.CreateDirectory(path);
        
        pathleft = Path.Combine(path, "LeftEyeRotation.txt");
        pathright = Path.Combine(path, "RightEyeRotation.txt");
        headposfile = Path.Combine(path, "HeadPosition.txt");
        headrotfile = Path.Combine(path, "HeadRotation.txt");
    }

    void Update()
    {
        if (!startMenu.running) return; // Only update when startMenu is running

        timer += Time.deltaTime;

        if (state == 0 && timer >= 10f)
        {
            Passthrough.SetActive(true);
            stateString = "passthrough";
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(0, 0, 0, 0); // Fully transparent
            Debug.Log("Switching to clear");
            state = 1;
            timer = 0f;
        }
        else if (state == 1 && timer >= 10f)
        {
            Passthrough.SetActive(false);
            stateString = "skybox";
            cam.clearFlags = CameraClearFlags.Skybox;
            Debug.Log("Switching to skybox");
            state = 2;
            timer = 0f;
        }
        else if (state == 2 && timer >= 10f)
        {
            smiley.SetActive(false);
            this.enabled = false;
        }
        if (startMenu.recording)
        {
            RecordTrackingData();
        }
    }

    void RecordTrackingData()
    {
        if (LeftEyeGaze.EyeTrackingEnabled && RightEyeGaze.EyeTrackingEnabled)
        {
            Vector3 leftEyeEuler = ConvertToMinus180To180(LeftEyeGaze.transform.rotation.eulerAngles);
            Vector3 rightEyeEuler = ConvertToMinus180To180(RightEyeGaze.transform.rotation.eulerAngles);
            Vector3 headsetPosition = transform.position;
            Quaternion headsetRotation = transform.rotation;

            try
            {
                File.AppendAllText(pathleft, $"{leftEyeEuler.x}, {leftEyeEuler.y}, {leftEyeEuler.z}, {stateString}\n");
                File.AppendAllText(pathright, $"{rightEyeEuler.x}, {rightEyeEuler.y}, {rightEyeEuler.z}, {stateString}\n");
                File.AppendAllText(headposfile, $"{headsetPosition.x}, {headsetPosition.y}, {headsetPosition.z}, {stateString}\n");
                File.AppendAllText(headrotfile, $"{headsetRotation.eulerAngles.x}, {headsetRotation.eulerAngles.y}, {headsetRotation.eulerAngles.z}, {stateString}\n");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to write tracking data: {ex.Message}");
            }
        }
    }

    // Converts a Vector3 of Euler angles to the range [-180, 180]
    Vector3 ConvertToMinus180To180(Vector3 eulerAngles)
    {
        return new Vector3(
            ConvertAngleToMinus180To180(eulerAngles.x),
            ConvertAngleToMinus180To180(eulerAngles.y),
            ConvertAngleToMinus180To180(eulerAngles.z)
        );
    }

    // Converts a single angle to the range [-180, 180]
    float ConvertAngleToMinus180To180(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }
}

