﻿using Microsoft.AspNetCore.Mvc;
using PFservice.Models;
using PFservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PFservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {

        private readonly IUtilisateurRepository _urepo;
        private readonly IEvenementRepository _erepo;

        public UtilisateurController(IUtilisateurRepository urepo,IEvenementRepository erepo)
        {
            _urepo = urepo;
            _erepo = erepo;
        }


        // GET: api/<UtilisateurController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Utilisateur>> Get()
        {
            return await _urepo.GetAllUtilisateurs();
        }

        // GET api/<UtilisateurController>/5
        [HttpGet("GetById/{id}")]
        public async Task<Utilisateur> GetUserById(int id)
        {
            return await _urepo.GetUtilisateurParId(id);
        }

        [HttpGet("GetByName")]
        public async Task<IEnumerable<Utilisateur>> GetByName(string name)
        {
            return await _urepo.GetUtilisateursParNom(name);
        }

        // POST api/<UtilisateurController>
        [HttpPost("New")]
        public async Task Post([FromBody] Utilisateur u)
        {
            u.DateCreation = DateTime.Now.Date;
            await _urepo.Create(u);
        }

        [HttpPost("Login")]
        public async Task<Utilisateur> Post(string userName, string password)
        {
            return await _urepo.GetUtilisateurLogin(userName, password);
        }

        // PUT api/<UtilisateurController>/5
        [HttpPut("Update")]
        public async Task UpdateUtilisateur([FromBody] Utilisateur utilisateur)
        {
            await _urepo.Update(utilisateur);
        }

        // DELETE api/<UtilisateurController>/5
        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await _urepo.Delete(id);
        }

        [HttpPost("NewUtilisateurEvenement")]
        public async Task NewUtilisateurEvenement([FromForm] Utilisateur u, Evenement e)
        {
            await _urepo.CreateUtilisateurEvenement(u, e);
        }

        [HttpDelete("DeleteUtilisateurEvenement")]
        public async Task DeleteUtilisateurEvenement(Utilisateur u, Evenement e )
        {
            await _urepo.DeleteUtilisateurEvenement(u, e);
        }
    }
}
