using System;

namespace TP_DL.Objects
{
    public abstract class PaymentType
    {
        private Guid Id;
        private DateTimeOffset boughtDate;

        public PaymentType(Guid id, DateTimeOffset date)
        {
            Id = id;
            boughtDate = date;
        }
    }
}
