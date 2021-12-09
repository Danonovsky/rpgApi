using System;

namespace rpg.DAO.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModyfiDateTime { get; set; }
    }
}