using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinksManager.Entities;

namespace LinksManager.Models
{
    public class LinkModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public static explicit operator LinkEntity(LinkModel linkModel)
        {
            LinkEntity linkEntity = new LinkEntity()
            {
                Id = linkModel.Id,
                Title = linkModel.Title,
                CreationDate = linkModel.CreationDate
            };

            return linkEntity;
        }

        public static explicit operator LinkModel(LinkEntity linkEntity)
        {
            LinkModel linkModel = new LinkModel()
            {
                Id = linkEntity.Id,
                Title = linkEntity.Title,
                CreationDate = linkEntity.CreationDate
            };

            return linkModel;
        }
    }
}