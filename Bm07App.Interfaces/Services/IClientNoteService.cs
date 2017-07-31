using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm07App.Models;

namespace Bm07App.Interfaces.Services
{
    public interface IClientNoteService
    {
        void Add(ClientNote clientNote);
        void Edit(ClientNote clientNote);
        void Delete(ClientNote clientNote);

        ClientNote GetClientNoteById(int id);
        List<ClientNote> GetClientNotesByClientId(int clientId);
    }
}
