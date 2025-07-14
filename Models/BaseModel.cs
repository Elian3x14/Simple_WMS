namespace TKS_intern.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        // Không dùng đến nhưng vẫn cần lưu lại để log
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public override string ToString()
        {
            return $"{GetType().Name} (Id: {Id}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt})";
        }
    }
}
