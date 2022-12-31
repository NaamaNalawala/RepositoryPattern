using System.Text.Json.Serialization;

namespace CatsyOnlineStore.Model.Models
{
    public class BaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedAt { get; } = DateTime.Now;

    }
}
