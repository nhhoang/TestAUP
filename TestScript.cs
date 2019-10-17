using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {
  double t = 0;
  // Start is called before the first frame update
  void Start() {
    DontDestroyOnLoad(gameObject);
    Invoke("Test", 1.0f);
  }

  void OnEnable() {
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  void OnDisable() {
    SceneManager.sceneLoaded -= OnSceneLoaded;
  }

  // Update is called once per frame
  void Test() {
    t = Time.realtimeSinceStartup;
    PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Loading;
    SceneManager.LoadSceneAsync("The_Viking_Village");

  }

  void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    Debug.Log(scene.name + " Scene loaded in " + ( Time.realtimeSinceStartup - t) + " seconds");

    PerformanceTuner.Mode = PerformanceTuner.PerformanceMode.Gameplay;
  }
}