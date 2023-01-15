using System.ComponentModel.DataAnnotations;

namespace PlatformBase.Core.Abstract
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public void SetIsActive(bool value)
        {
            IsActive = value;
        }
    }
}
