using UnityEngine;

public class DialogueResources
{
    public Sprite ClownPhoto;
    public Sprite BallClownPhoto;
    public Sprite BigTopBackground;

    public void PreLoadClowns()
    {
        ClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        BallClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
    }

    public void PreLoadBackgrounds()
    {
        BigTopBackground = Resources.Load<Sprite>(@$"TestAssets\Background_TestImage");
    }
}
