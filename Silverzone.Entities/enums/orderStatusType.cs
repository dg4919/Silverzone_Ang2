namespace Silverzone.Entities
{
    // for all enums we suffix with type > so that we can know this is a enum type
    public enum orderStatusType
    {
        Pending,
        Dipatched,
        Intransit,
        Delivered,
        Canceled,
        Failed,
        Refund
    }
}
