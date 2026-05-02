using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Prueba_tecnica_Meddi_back.Meddi.Catalogos;
using Prueba_tecnica_Meddi_back.Meddi.dbContext;
using Prueba_tecnica_Meddi_back.Meddi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace Prueba_tecnica_Meddi_back.Meddi.Api.Controllers{

    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly MeddiMongoContext _context;
        private readonly IMapper _mapper;

        public TasksController(MeddiMongoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api/tasks
        /// </summary>
        [HttpGet]
        public async Task<GenericResponse> GetTasks()
        {
            var mResponse = new GenericResponse();
            try
            {
                var tasks = await _context.TaskItems.Find(_ => true).ToListAsync();
                mResponse.Data = _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
                mResponse.Success = true;
            }
            catch (Exception ex)
            {
                mResponse.Success = false;
                mResponse.Message = ex.Message;
            }
            return mResponse;
        }

        /// <summary>
        /// GET api/tasks/{id}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<GenericResponse> GetTaskById(string id)
        {
            var mResponse = new GenericResponse();
            try
            {
                var task = await _context.TaskItems.Find(t => t.Id == id).FirstOrDefaultAsync();
                if (task == null) throw new Exception("Tarea no encontrada.");

                mResponse.Data = _mapper.Map<TaskItemDto>(task);
                mResponse.Success = true;
            }
            catch (Exception ex)
            {
                mResponse.Success = false;
                mResponse.Message = ex.Message;
            }
            return mResponse;
        }

        /// <summary>
        /// POST api/tasks
        /// </summary>
        [HttpPost]
        public async Task<GenericResponse> CreateTask(CreateTaskDto createDto)
        {
            var mResponse = new GenericResponse();
            try
            {
                var taskEntity = _mapper.Map<TaskItem>(createDto);
                await _context.TaskItems.InsertOneAsync(taskEntity);

                mResponse.Success = true;
                mResponse.Message = "Tarea creada correctamente";
                mResponse.Data = taskEntity.Id;
            }
            catch (Exception ex)
            {
                mResponse.Success = false;
                mResponse.Message = ex.Message;
            }
            return mResponse;
        }

        /// <summary>
        /// PUT api/tasks/{id}
        /// </summary>
        [HttpPut("{id}")]
        public async Task<GenericResponse> UpdateTask(string id, CreateTaskDto updateDto)
        {
            var mResponse = new GenericResponse();
            try
            {
                var taskEntity = _mapper.Map<TaskItem>(updateDto);
                taskEntity.Id = id;

                var result = await _context.TaskItems.ReplaceOneAsync(t => t.Id == id, taskEntity);

                if (result.MatchedCount == 0) throw new Exception("No se encontró el registro.");

                mResponse.Success = true;
                mResponse.Message = "Registro actualizado";
            }
            catch (Exception ex)
            {
                mResponse.Success = false;
                mResponse.Message = ex.Message;
            }
            return mResponse;
        }

        /// <summary>
        /// DELETE api/tasks/{id}
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<GenericResponse> DeleteTask(string id)
        {
            var mResponse = new GenericResponse();
            try
            {
                var result = await _context.TaskItems.DeleteOneAsync(t => t.Id == id);
                if (result.DeletedCount == 0) throw new Exception("La tarea no existe.");

                mResponse.Success = true;
                mResponse.Message = "Tarea eliminada";
            }
            catch (Exception ex)
            {
                mResponse.Success = false;
                mResponse.Message = ex.Message;
            }
            return mResponse;
        }
    }
}

        // Clase auxiliar para las respuestas
        public class GenericResponse
        {
            public bool Success { get; set; } = true;
            public string Message { get; set; } = string.Empty;
            public object Data { get; set; }
        }
    

