using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabObject : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    Debug.Log("=========Last prefab loaded in " + (Time.realtimeSinceStartup - TestAUP.startLoadTime));
  }

  // Update is called once per frame
  void Update() {

  }
}