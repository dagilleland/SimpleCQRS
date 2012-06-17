﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCqrs.Domain;
using SimpleCqrs.Eventing;

namespace ECommDemo.Domain.InventoryContext
{
    public class InventoryItemCreatedEvent : DomainEvent
    {
        public string ItemId { get; protected set; }
        public string Description { get; protected set; }

        public InventoryItemCreatedEvent(string itemId, string description)
        {
            ItemId = itemId;
            Description = description;
        }
    }

    public class InventoryItem : AggregateRoot
    {
        public string ItemId { get; protected set; }
        public string Description { get; protected set; }
        public decimal Availability { get; protected set; }
        public string UnitOfMeasure { get; protected set; }

        public InventoryItem()
        {
        }

        public InventoryItem(string id, string description)
        {
            Apply(new InventoryItemCreatedEvent(id, description)
                      {
                          AggregateRootId = Guid.NewGuid()
                      });
        }


        protected void OnItemCreated(InventoryItemCreatedEvent e)
        {
            this.Id = e.AggregateRootId;
            this.ItemId = e.ItemId;
            this.Description = e.Description;
        }

    }
}