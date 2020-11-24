using System;
using System.Collections.Generic;

namespace pet_shop.api.Domain
{
    public class CartRepository: ICartRepository
    {
        public IEnumerable<Guid> GetItems()
        {
            return _items;
        }

        public void AddItem(Guid petId)
        {
            if (_items.Contains(petId))
            {
                throw new Exception($"Элемент с Id {petId} уже добавлен в корзину.");
            }
            _items.Add(petId);
        }

        public void RemoveItem(Guid petId)
        {
            if (!_items.Contains(petId))
            {
                throw new Exception($"Элемента с Id {petId} нет в корзине.");
            }
            _items.Remove(petId);
        }

        public void RemoveAllItems()
        {
            _items.Clear();
        }

        private readonly List<Guid> _items = new List<Guid>();
    }
}