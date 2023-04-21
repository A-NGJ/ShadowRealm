using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    public GameObject xrOrigin;
    public GameObject desktopCharacter;
    public bool startInVR = true;

    public void DetectAndEnableVR() {
        var xrSettings = XRGeneralSettings.Instance;        
        xrOrigin.SetActive(false);
        desktopCharacter.SetActive(true);
    
        if (xrSettings == null) {
            Debug.Log("No XRGeneralSettings in the scene. VR not supported.");
            return;
        }

        var xrManager = xrSettings.Manager;
        if (xrManager == null) {
            Debug.Log("No XRManager in XRGeneralSettings. VR not supported.");
            return;
        }

        var xrLoader = xrManager.activeLoader;
        if (xrLoader == null) {
            Debug.Log("No XRLoader in XRManager. VR not supported.");
            return;
        }

        Debug.Log("XRLoader name: " + xrLoader.name);
        xrOrigin.SetActive(true);
        desktopCharacter.SetActive(false);
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startInVR) {
            DetectAndEnableVR();
        } else {
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
        }
    }
}
