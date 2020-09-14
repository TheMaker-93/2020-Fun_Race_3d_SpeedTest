public sealed class CameraToRightTrigger : CameraAnimationTrigger
{
    protected override void ProcessTriggerEnter(CameraAnimationController cam)
    {
        cam.PlayCenterToRightAnimation();
    }

    protected override void ProcessTriggerExit(CameraAnimationController cam)
    {
        cam.ResetCenteredView();
    }
}