using UnityEngine;

namespace ElementStudio.Pivotal.Manager
{
    public class VideoSettings
    {
        public static void ApplySettings()
        {
            Resolution newResolution = Screen.resolutions[NewPivotalManager.instance.settings.video.resolutionIndex];
            bool fs = NewPivotalManager.instance.settings.video.useFullscreen;
            FullScreenMode fullscreenMode = (NewPivotalManager.instance.settings.video.useExclusiveFullscreen) ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.MaximizedWindow;
            fullscreenMode = (fs) ? fullscreenMode : FullScreenMode.Windowed;
            int syncCount = (NewPivotalManager.instance.settings.video.syncEveryFrame) ? 1 : 0;

            if (newResolution.width != Screen.currentResolution.width || newResolution.height != Screen.currentResolution.height || fullscreenMode != Screen.fullScreenMode)
            {
                Screen.SetResolution(newResolution.width, newResolution.height, fullscreenMode, newResolution.refreshRate);
            }

            QualitySettings.vSyncCount = syncCount;
            QualitySettings.antiAliasing = NewPivotalManager.instance.settings.video.antiAliasingIndex;
            NewPivotalManager.instance.settings.Save();
        }
    }
}