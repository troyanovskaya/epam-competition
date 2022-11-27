using System;

namespace LocalGoods.DAL.Entities
{
    public class ContactInformation: AuditEntity
    {
        public string TelegramName { get; set; }
        public string InstagramName { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
