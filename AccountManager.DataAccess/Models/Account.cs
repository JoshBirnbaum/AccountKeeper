using System;
using System.Collections.Generic;

namespace AccountManager.DataAccess.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string AccountName { get; set; } = null!;
    }
}
