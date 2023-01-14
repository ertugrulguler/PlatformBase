namespace PlatformBase.Core.Abstract
{
    public abstract class Entity
    {
        public bool Success { get; set; }
        public bool FromCache { get; set; }
        public string ErrorMessage { get; set; }
        public string UserMessage { get; set; }
    }
}
