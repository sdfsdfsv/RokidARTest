using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImportTest 
{
    // 文件导入逻辑
    public static string ImportFile()
    {
        // 检查平台是否为Android
        if (Application.platform == RuntimePlatform.Android)
        {
            // 使用Android的文件选择器
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
            string filePath = currentActivity.Call<string>("openFilePicker");

            // 检查文件路径是否有效
            if (!string.IsNullOrEmpty(filePath))
            {
                // 在这里可以处理导入文件的逻辑，例如加载文件内容或进行其他操作
                Debug.Log("选择的文件路径：" + filePath);
                return filePath;
            }
            
        }
        else
        {
            // 在Unity编辑器中使用文件选择器
            string filePath = UnityEditor.EditorUtility.OpenFilePanel("选择文件", "", "");

            // 检查文件路径是否有效
            if (!string.IsNullOrEmpty(filePath))
            {
                // 在这里可以处理导入文件的逻辑，例如加载文件内容或进行其他操作
                Debug.Log("选择的文件路径：" + filePath);
                return filePath;
            }
        }
        return null;
    }
}
