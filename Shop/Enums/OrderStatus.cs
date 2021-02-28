using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Enums
{
    public enum OrderStatus
    {
        New,
        PaymentReceived,
        SentToUser,
        CancelledByUser,
        CancelledByAdministrator,
        Received
    }
}
