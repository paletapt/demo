using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        /// <summary>
        /// Get contacts from cache
        /// </summary> 
        /// <returns> return list of contacts </returns>
        public Contact[] Get()
        {
          return  contactRepository.GetAllContacts();

        }

        /// <summary>
        /// Add new contact to cache
        /// </summary>
        /// <param name="contact"> Contact (ID:int; Name:string)</param>
        /// <returns> HTTP Response</returns>
      
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);
            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return response;

        }
          
    }
}
