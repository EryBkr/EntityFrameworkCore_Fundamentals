﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreFundamentals
{
    public class Address
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }//Foreing Key , ilişkinin tek tarafı
        public User User { get; set; }//Navigation Property
    }
}
