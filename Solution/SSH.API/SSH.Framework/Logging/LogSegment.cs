namespace SSH.Framework.Logging
{
    public class LogSegment
    {
        public string SegmentName { get; set; }

        public LogSegment(string segmentName)
        {
            SegmentName = segmentName;
        }

        public LogSegment(object instanceContext, string segmentName)
        {
            SegmentName = instanceContext.GetType().FullName + "." + segmentName;
        }

        public LogSegment(Type type)
        {
            SegmentName = type.FullName;
        }
    }
}
