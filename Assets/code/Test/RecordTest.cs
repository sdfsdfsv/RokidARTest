using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Rokid.UXR.Interaction;
using Rokid.UXR.Module;
using UnityEngine.Android;

//test record function, yet not working on debugging environment
public class RecordTest : MonoBehaviour
{
    private void Awake()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.RECORD_AUDIO"))
        {
            Permission.RequestUserPermission("android.permission.RECORD_AUDIO");
        }
    }
    void Start()
    {
        ModuleManager.Instance.RegistModule("com.rokid.voicecommand.VoiceCommandHelper", false);
        OfflineVoiceModule.Instance.AddInstruct(LANGUAGE.ENGLISH, "show blue", null, this.gameObject.name, "OnReceive");

        OfflineVoiceModule.Instance.AddInstruct(LANGUAGE.CHINESE, "变成蓝色", "bian cheng lan se", this.gameObject.name, "OnReceive");

        OfflineVoiceModule.Instance.Commit();
    }
        public void OnReceive(string msg)
    {
        Debug.Log("voice command: " + msg);
    }
    private void OnDestroy()
    {
        OfflineVoiceModule.Instance.ClearAllInstruct();
        OfflineVoiceModule.Instance.Commit();
    }
}
