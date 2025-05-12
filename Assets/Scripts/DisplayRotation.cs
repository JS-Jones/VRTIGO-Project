using UnityEngine;
using TMPro;
using System.IO;
using System;

public class DisplayRotation : MonoBehaviour
{
    // OVREyeGaze components for tracking left and right eye rotation
    public OVREyeGaze LeftEyeGaze;
    public OVREyeGaze RightEyeGaze;

    // UI elements to display rotation values
    public TextMeshProUGUI LRotationX;
    public TextMeshProUGUI LRotationY;
    public TextMeshProUGUI LRotationZ;
    public TextMeshProUGUI RRotationX;
    public TextMeshProUGUI RRotationY;
    public TextMeshProUGUI RRotationZ;

    // Visual indicator of recording state
    public GameObject Sphere;

    public MoveBetweenTwoTransforms MoveBetweenTwoTransforms;

    // File paths for saving rotation data
    public string pathleft, pathright, path;
    public string headposfile, headrotfile;

    // Variables to manage recording state
    //private int record, onoff;
    private Transform centerEyeAnchor;
    public StartSystem startMenu;

    // Called when the script instance is being loaded
    void OnEnable()
    {

        // Locate the OVRCameraRig
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null)
        {
            centerEyeAnchor = cameraRig.centerEyeAnchor;
            Debug.Log("OVRCameraRig found in the scene!");
        }
        else
        {
            Debug.LogError("OVRCameraRig not found in the scene!");
        }
        // Initialize file paths only once
        
            // Use Application.persistentDataPath to ensure cross-platform compatibility
        path = Path.Combine(Application.persistentDataPath, "TestOfNystagmus");
        path = Path.Combine(path, StartSystem.playerName);
        path = Path.Combine(path, System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
        

        // Create directory for storing data
         try
        {
            Directory.CreateDirectory(path);
            Debug.Log($"Directory created: {path}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to create directory: {ex.Message}");
        }

        pathleft = Path.Combine(path, "LeftEyeRotation.txt");
        pathright = Path.Combine(path, "RightEyeRotation.txt");
        headposfile = Path.Combine(path, "HeadPosition.txt");
        headrotfile = Path.Combine(path, "HeadRotation.txt");

        if (startMenu.running){
            MoveBetweenTwoTransforms.enabled = true; 
        }
        

        // Initialize recording state and set sphere color to red
        //record = 0;
        //Sphere.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // Called once per frame
    void Update()
    {
        Vector3 headsetPosition = Vector3.zero;
        Quaternion headsetRotation = Quaternion.identity;

        if (centerEyeAnchor != null)
        {
            headsetPosition = centerEyeAnchor.position;
            headsetRotation = centerEyeAnchor.rotation;
        }

        // Toggle recording on button press (Right Controller, Button One)
        // if ((OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) && record == 0)
        // {
        //     record = 1;
        //     //Sphere.gameObject.GetComponent<Renderer>().material.color = Color.green; // Change sphere color to green
        //     MoveBetweenTwoTransforms.enabled = true; // Enable movement script
        // }

        // // Stop recording on button press (Right Controller, Button Two)
        // if ((OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) && record == 1)
        // {
        //     record = 0;
        //     //Sphere.gameObject.GetComponent<Renderer>().material.color = Color.red; // Change sphere color to red
        //     MoveBetweenTwoTransforms.enabled = false; // disable movement script
        // }

        // Record eye rotation data if recording is active and eye tracking is enabled
        if (startMenu.recording && LeftEyeGaze.EyeTrackingEnabled && RightEyeGaze.EyeTrackingEnabled)
        {
            // Process and display left eye rotation
            Vector3 leftEyeEuler = LeftEyeGaze.transform.rotation.eulerAngles;
            Vector3 leftEyeConverted = ConvertToMinus180To180(leftEyeEuler);

            // LRotationX.text = "Left eye X Rotation: " + leftEyeConverted.x.ToString();
            // LRotationY.text = "Left eye Y Rotation: " + leftEyeConverted.y.ToString();
            // LRotationZ.text = "Left eye Z Rotation: " + leftEyeConverted.z.ToString();

            // Process and display right eye rotation
            Vector3 rightEyeEuler = RightEyeGaze.transform.rotation.eulerAngles;
            Vector3 rightEyeConverted = ConvertToMinus180To180(rightEyeEuler);

            // RRotationX.text = "Right eye X Rotation: " + rightEyeConverted.x.ToString();
            // RRotationY.text = "Right eye Y Rotation: " + rightEyeConverted.y.ToString();
            // RRotationZ.text = "Right eye Z Rotation: " + rightEyeConverted.z.ToString();

            // Save left and right eye data to file
            try
            {
                File.AppendAllText(pathleft, MoveBetweenTwoTransforms.phase + ", " + leftEyeConverted.x + ", " + leftEyeConverted.y + ", " + leftEyeConverted.z + "\n");
                File.AppendAllText(pathright, MoveBetweenTwoTransforms.phase + ", " + rightEyeConverted.x + ", " + rightEyeConverted.y + ", " + rightEyeConverted.z + "\n");
                File.AppendAllText(headposfile, MoveBetweenTwoTransforms.phase + ", " + headsetPosition.x + ", " + headsetPosition.y + ", " + headsetPosition.z + "\n");
                File.AppendAllText(headrotfile, MoveBetweenTwoTransforms.phase + ", " + headsetRotation.eulerAngles.x + ", " + headsetRotation.eulerAngles.y + ", " + headsetRotation.eulerAngles.z + "\n");
                
                //Debug.Log("Head position written successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to write head position: {ex.Message}");
                // LRotationX.text = "Failed to write head position";
                // LRotationX.text = $"Failed to write head position: {ex.Message}";

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
