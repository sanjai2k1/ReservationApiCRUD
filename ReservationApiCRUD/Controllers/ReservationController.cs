﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ReservationApiCRUD.Models;
using System.Collections;

namespace ReservationApiCRUD.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IRepository _repository;


        public ReservationController(IRepository repository)
        {
            _repository = repository;
        }
 [HttpPost]
    public async Task<IActionResult> AddReservation( Reservation reservation)
    {
        if (reservation == null)
        {
            return BadRequest();
        }

        var createdReservation = await _repository.AddReservationAsync(reservation);
            return Ok(createdReservation);
    }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _repository.GetAll();
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var reservation = await _repository.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) => await _repository.DeleteReservation(id) ? Ok() : NotFound();


        [HttpPut]

        public async Task<ActionResult<Reservation>> UpdateReservation(Reservation updatedReservation)
        {
            return await _repository.UpdateReservation(updatedReservation);
        }
    }
}
