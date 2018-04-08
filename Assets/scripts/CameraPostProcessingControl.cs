using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraPostProcessingControl : MonoBehaviour
{
    private PostProcessingBehaviour behaviour;
    private PostProcessingProfile ppProfile;


    void Start()
    {
        behaviour = GetComponent<PostProcessingBehaviour>();
        ppProfile = behaviour.profile;
     }

    void TogglePostProcessing()
    {
        behaviour.enabled = !behaviour.enabled;
    }
    void ToggleColorGrading()
    {
        ppProfile.colorGrading.enabled = !ppProfile.colorGrading.enabled;
    }
    void ToggleDepthOfField()
    {
        ppProfile.depthOfField.enabled = !ppProfile.depthOfField.enabled;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePostProcessing();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleColorGrading();

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ToggleDepthOfField();

        }
    }


    void ChangeBloomAtRuntime()
    {
        //copy current bloom settings from the profile into a temporary variable
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;

        //change the intensity in the temporary settings variable
        bloomSettings.bloom.intensity = 2;

        //set the bloom settings in the actual profile to the temp settings with the changed value
        ppProfile.bloom.settings = bloomSettings;
    }
}