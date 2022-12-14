using System;

namespace LocalGoods.Shared
{
    public static class GlobalValues
    {
        public static Guid NewOrderStatusId = new Guid("5cd43639-e879-4331-9e3b-019537bb729b");
        public static Guid PendingOrderStatusId = new Guid("6f0a355f-c0b1-46a3-a93a-94fad9aa1ed3");
        public static Guid PaidOrderStatusId = new Guid("de780f77-888f-44e8-be34-d796f5342b55");
        public static Guid CompletedOrderStatusId = new Guid("17cf0057-aa23-4cdf-96a4-6573c7ae96e6");
        public static Guid CanceledOrderStatusId = new Guid("712572b2-5991-48eb-a882-5b842dcfc5bf");
    }
}
