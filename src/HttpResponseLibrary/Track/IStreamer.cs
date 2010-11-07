namespace HttpResponseLibrary.Track
{
    public interface IStreamer
    {
        TrackStreamResponse StreamTrack(string filePath);
    }
}