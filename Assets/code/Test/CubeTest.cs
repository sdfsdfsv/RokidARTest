using Rokid.UXR.Interaction;
using UnityEngine;


// test 3Dof radial interaction
public class CubeTest : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private InteractableUnityEventWrapper unityEvent;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        unityEvent = GetComponent<InteractableUnityEventWrapper>();

        unityEvent.WhenSelect.AddListener(() =>
        {
            //Pointer Down
            meshRenderer.material.SetColor("_Color", Color.red);
        });

        unityEvent.WhenUnselect.AddListener(() =>
        {
            //Pointer Up
            meshRenderer.material.SetColor("_Color", Color.white);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
