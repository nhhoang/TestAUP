using UnityEngine;
public static class PerformanceTuner {
  public enum PerformanceMode {
    Loading,
    Gameplay
  }

  private static readonly int _defaultVSyncCount;
  private static readonly int _defaultTargetFramerate;
  private static readonly int _defaultTimeSlice;
  private static readonly int _defaultBufferSize;
  private static PerformanceMode _mode = PerformanceMode.Gameplay;

  static PerformanceTuner() {
    _defaultVSyncCount = QualitySettings.vSyncCount;
    _defaultTargetFramerate = Application.targetFrameRate;
    _defaultTimeSlice = QualitySettings.asyncUploadTimeSlice;
    _defaultBufferSize = QualitySettings.asyncUploadBufferSize;
  }

  public static PerformanceMode Mode {
    get => _mode;
    set {
      if (_mode != value) {
        _mode = value;
        if (_mode == PerformanceMode.Loading) {
          Application.backgroundLoadingPriority = ThreadPriority.High;
          QualitySettings.asyncUploadTimeSlice = 33;
          QualitySettings.asyncUploadBufferSize = 32;
          QualitySettings.vSyncCount = 0;
          Application.targetFrameRate = 10000;
        } else if (_mode == PerformanceMode.Gameplay) {
          Application.backgroundLoadingPriority = ThreadPriority.Normal;
          QualitySettings.asyncUploadTimeSlice = _defaultTimeSlice;
          QualitySettings.asyncUploadBufferSize = _defaultBufferSize;
          QualitySettings.vSyncCount = _defaultVSyncCount;
          Application.targetFrameRate = _defaultTargetFramerate;
        }
      }
    }
  }
}