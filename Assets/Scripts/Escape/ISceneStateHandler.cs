namespace Assets.Scripts.Escape
{
    public interface ISceneStateHandler
    {
        SceneState State { get; set; }
        void InitializeState();
    }
}