﻿using Domain.Payment;
using Domain.Payment.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class PaymentSettingsRepository : BaseRepository<PaymentSettings>, IPaymentSettingsRepository
{
    public PaymentSettingsRepository(LaptopParhizgerContext context) : base(context)
    {
    }
}