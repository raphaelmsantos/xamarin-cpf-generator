using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CpfGenerator.Entities
{
    public class Cpf
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GeneratedNumber { get; set; }

        public override string ToString()
        {
            return GeneratedNumber;
        }
    }
}
