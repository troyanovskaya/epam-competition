using System;

namespace LocalGoods.DAL.Entities
{
    public class ContactInformation: AuditEntity<Guid>
    {
        public string ViberNumber { get; set; }
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }
        
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
