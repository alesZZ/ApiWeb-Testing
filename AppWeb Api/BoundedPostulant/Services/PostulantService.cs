using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Repository;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedPostulant.Domain.Service.Communication;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Interfaces;
using AppWeb_Api.BoundedSecurity.Exceptions;
using AppWeb_Api.Common.Domain.Repositories;
using AutoMapper;

namespace AppWeb_Api.BoundedPostulant.Services
{
    public class PostulantService : IPostulantService
    {
        private readonly IPostulantRepository _postulantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public PostulantService(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _postulantRepository = postulantRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<Postulant> GetIdAsync(int id)
        {
            return await _postulantRepository.FindByIdAsync(id);
        }
        /*public async Task<Postulant> GetIdAsync(int id)
        {
            var postulant= await _postulantRepository.FindByIdAsync(id);
            if (postulant == null) throw new KeyNotFoundException("User not found.");
            return postulant;
        }*/

        public async Task<IEnumerable<Postulant>> ListAsync()
        {
            return await _postulantRepository.ListAsync();
        }

        public async Task<PostulantResponse> SaveAsync(Postulant postulant)
        {
            if (_postulantRepository.ExistsByEmail(postulant.Email))
                throw new AppException($"Username {postulant.Email} is already taken.");
            try
            {
                await _postulantRepository.AddAsync(postulant);
                await _unitOfWork.CompleteAsync();
                return new PostulantResponse(postulant);
            }
            catch(Exception e)
            {
                return new PostulantResponse($"An error ocurred while saving postulant:{e.Message}");
            }
        }

        public async Task<PostulantResponse> UpdateAsync(int id, Postulant postulant)
        {
            var existingPostulant = await _postulantRepository.FindByIdAsync(id);
            if (existingPostulant == null)
            {
                return new PostulantResponse("Postulant not found");
            }
            existingPostulant.Name = postulant.Name;
            existingPostulant.LastName = postulant.LastName;
            existingPostulant.MySpecialty = postulant.MySpecialty;
            existingPostulant.MyExperience = postulant.MyExperience;
            existingPostulant.Description = postulant.Description;
            existingPostulant.ImgPostulant = postulant.ImgPostulant;
            existingPostulant.NameGithub = postulant.NameGithub;
            try
            {
                _postulantRepository.Update(existingPostulant);
                await _unitOfWork.CompleteAsync();
                return new PostulantResponse(existingPostulant);
            }
            catch(Exception e)
            {
                return new PostulantResponse($"An error ocurred while updating the postulant{e.Message}");
            }
        }

        public async Task<Postulant> GetByEmailAndPassword(string email, string password)
        {
            var postulant= await _postulantRepository.FindByEmailAndPasswordAsync(email, password);
            return postulant;
        }
        

        public async Task<AuthenticatePostulantResponse> Authenticate(AuthenticatePostulantRequest request)
        {
            var user = await _postulantRepository.FindByEmailAndPasswordAsync(request.Email,request.Password);
            
            // Validate

            if (user == null )
                throw new AppException("Username or password is incorrect.");
            
            // Authentication is successful

            var response = _mapper.Map<Postulant,AuthenticatePostulantResponse>(user);

            response.Token = _jwtHandler.GenerateTokenPostulant(user);

            return response;
        }
    }
}
