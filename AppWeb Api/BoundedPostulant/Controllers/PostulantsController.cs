using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedPostulant.Resources;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedPostulant.Domain.Service.Communication;
using AppWeb_Api.BoundedSecurity.Authorization.Attributes;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppWeb_Api.BoundedPostulant.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PostulantsController:ControllerBase
    {
        private readonly IPostulantService _postulantService;
        private readonly IMapper _mapper;

        public PostulantsController(IPostulantService postulantService, IMapper mapper)
        {
            _postulantService = postulantService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PostulantResource>> GetAllAsync()
        {
            var postulants = await _postulantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Postulant>, IEnumerable<PostulantResource>>(postulants);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<PostulantResource> GetByIdAsync(int id)
        {
            var postulant = await _postulantService.GetIdAsync(id);
            
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(postulant);
            return postulantResource;
        }
        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult>PostAsync([FromBody]SavePostulantResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var postulant = _mapper.Map<SavePostulantResource, Postulant>(resource);
            var result = await _postulantService.SaveAsync(postulant);
            if (!result.Succes)
                return BadRequest(result.Message);
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>PutAsync(int id,[FromBody] UpdatePostulantResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var postulant = _mapper.Map<UpdatePostulantResource, Postulant>(resource);
            var result = await _postulantService.UpdateAsync(id, postulant);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }
        [HttpGet]
        [Route("/api/v1/postulants/email/{email}/password/{password}")]
        public async Task<PostulantResource> GetByIdAsync(string email,string password)
        {
            var postulant = await _postulantService.GetByEmailAndPassword(email,password);
            
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(postulant);
            return postulantResource;
        }
        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticatePostulantRequest request)
        {
            var response = await _postulantService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(response);
        }
    }
}
