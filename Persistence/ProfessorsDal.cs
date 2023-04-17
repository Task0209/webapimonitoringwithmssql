using app11.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app11.Persistence
{

    public class ProfessorsDal
    {
        private readonly CollegeDbContext _collegeDbContext;

        public ProfessorsDal(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public IEnumerable<Professor> GetProfessors()
        {
            return _collegeDbContext.Professors
                .ToList();
        }


        public Professor GetProfessorById(int id)
        {
            if (!_collegeDbContext.Professors.Any(record => record.ProfessorId == id))
            {
                return null;
            }

            return _collegeDbContext.Professors
                .Where(record => record.ProfessorId == id)
                .FirstOrDefault();
        }

        public Professor AddProfessor(Professor professor)
        {
            _collegeDbContext.Professors.Add(professor);

            _collegeDbContext.SaveChanges();

            return professor;
        }
    }

}