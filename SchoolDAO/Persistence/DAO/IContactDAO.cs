using SchoolDAO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDAO.Persistence.DAO
{
    public interface IContactDAO
    {
        public ContactDTO GetContactByID(int id);
        public IEnumerable<ContactDTO> GetAllContacts();
        public void AddContacts(List<ContactDTO> contacts);
        public void AddContact(ContactDTO contact);
        public void UpdateContact(ContactDTO contact);
        public void DeleteContact(int id);
    }
}
