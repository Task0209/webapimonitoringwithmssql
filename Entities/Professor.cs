using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace app11.Entities
{
    public class Professor
    {

        public int ProfessorId { get; set; }

        public string Name { get; set; }

        public string Teaches { get; set; }

    }

}