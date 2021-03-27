using System;
using System.Collections.Generic;

namespace pet_shop.api.Domain
{
    public interface ICartRepository
    {
        public IEnumerable<Guid> GetItems();
        public void AddItem(Guid petId);
        public void RemoveItem(Guid petId);
        public void RemoveAllItems();
    }
}