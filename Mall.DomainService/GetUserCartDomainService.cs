﻿using System;
using Mall.Domain;
using Mall.Domain.Aggregate;

namespace Mall.DomainService
{
    public class GetUserCartDomainService
    {
        public Cart GetUserCart(Guid userId)
        {
            var cart = DomainRegistry.CartRepository().GetByUserId(userId);
            if (cart == null)
            {
                cart = new Cart(DomainRegistry.CartRepository().NextIdentity(), userId, DateTime.Now);
                DomainRegistry.CartRepository().Save(cart);
            }

            return cart;
        }
    }
}
