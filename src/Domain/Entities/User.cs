﻿using Core.Models.Entities;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
    }
}
