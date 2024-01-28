using UnityEngine;

public class DialogueResources
{
    public Sprite ClownPhoto;
    public Sprite BallClownPhoto;
    public Sprite JohnClownPhoto;
    public Sprite JugglingClownPhoto;
    public Sprite GirlClownPhoto;

    public Sprite BigTopBackground;

    public void PreLoadClowns()
    {
        ClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        BallClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        JohnClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        GirlClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
        JugglingClownPhoto = Resources.Load<Sprite>(@$"ClownPortraits\JClown");
    }

    public void PreLoadBackgrounds()
    {
        BigTopBackground = Resources.Load<Sprite>(@$"TestAssets\Background_TestImage");
    }
}
