namespace Hospital.DAL.Entities
{
    public abstract class AdminConfig
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatorUser { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifirrUser { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeleterUser { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
