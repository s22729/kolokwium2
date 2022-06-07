using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kolos8.Services;
using kolos8.Models.Dtos;

namespace kolos8.Controllers
{
    [Route("[controller]")]
    public class MusicianController : ControllerBase
    {
        private readonly IDbMusicianService _musicianService;
        public MusicianController(IDbMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusician(int id){
            try{
                return Ok(await _musicianService.GetMusician(id));
            }catch{
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id){
            try{
                await _musicianService.DeleteMusician(id);
                return Ok();
            }catch{
                return NotFound();
            }
        }
    }
}