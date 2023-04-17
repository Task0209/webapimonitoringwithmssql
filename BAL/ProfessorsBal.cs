using app11.Entities;
using app11.Persistence;
using System;
using System.Collections.Generic;

namespace app11.BAL
{
    public class ProfessorsBal
    {
        private readonly ProfessorsDal _professorsData;

        public ProfessorsBal(ProfessorsDal professorsData)
        {
            _professorsData = professorsData;
        }

        public IEnumerable<Professor> GetProfessors()
        {
            return _professorsData.GetProfessors();
        }  

         public Professor GetProfessorById(int id)
        {
            return _professorsData.GetProfessorById(id);
        }

        public Professor AddProfessor(Professor professor)
        {
            return _professorsData.AddProfessor(professor);
        }

               
    }

}