namespace TestMusicAppServer.Common.CloseableListeners
{
    public interface ICloseableListener
    {
        void RegisterListener();

        void CloseListener();
    }
}
