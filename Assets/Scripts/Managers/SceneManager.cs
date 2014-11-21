using UnityEngine;
using System.Collections;

public static class SceneManager {

    public static void ChangeScene(int sceneIndex)
    {
        Application.LoadLevel(sceneIndex);
    }
}
