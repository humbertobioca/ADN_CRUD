using System.Collections.Generic;

namespace ApnCore_Crud.Models
{
    public interface IParticipanteDAL
    {
        IEnumerable<Participante> GetAllParticipantes();
        void AddParticipante(Participante participante);
        void UpdateParticipante(Participante participante);
        Participante GetParticipante(int? id);
        void DeleteParticipante(int? id);
    }
}
