using rpg.DAO.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Auth.Models.Response
{
    public class PublicUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PublicUserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
        }
    }
}
